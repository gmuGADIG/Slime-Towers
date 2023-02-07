using System.Collections;
using System.Linq;
using CleverCrow.Fluid.Databases;
using CleverCrow.Fluid.Dialogues.Graphs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CleverCrow.Fluid.Dialogues.Examples {
    public class DialoguePlayback : MonoBehaviour {
        private DialogueController _ctrl;

        [TextArea]
        [Tooltip("Doesn't do anything. Just comments shown in inspector")]
        public string Notes = "This component shouldn't be removed, it does important stuff.";

        public DialogueGraph dialogue;

        public GameObjectOverride[] gameObjectOverrides;

        [Header("Graphics")]
        public GameObject speakerContainer;
        public TMP_Text nameTag;
        public Image portrait;
        public TMP_Text lines;

        public RectTransform choiceList;
        public ChoiceButton choicePrefab;

        [Header("Additional actions")]
        public Behaviour[] enableOnEnd;

        private IEnumerator CurrShowTextRoutine;

        private void OnEnable () {
            
            GameState currGameState = ManagerScript.gm.getGameState();
            var database = new DatabaseInstanceExtended();
           _ctrl = new DialogueController(database);
           speakerContainer.SetActive(true);

           // @NOTE If you don't need audio just call _ctrl.Events.Speak((actor, text) => {}) instead
           _ctrl.Events.SpeakWithAudio.AddListener((actor, text, audioClip) => {
               if (audioClip) Debug.Log($"Audio Clip Detected ${audioClip.name}");

               nameTag.text = actor.DisplayName;
               ClearChoices();
               portrait.sprite = actor.Portrait;
               CurrShowTextRoutine = ShowText(text);
               StartCoroutine(CurrShowTextRoutine);
               StartCoroutine(NextDialogue());
           });

           _ctrl.Events.Choice.AddListener((actor, text, choices) => {
               nameTag.text = actor.DisplayName;
               ClearChoices();
               portrait.sprite = actor.Portrait;
               CurrShowTextRoutine = ShowText(text);
               StartCoroutine(CurrShowTextRoutine);

               choices.ForEach(c => {
                   var choice = Instantiate(choicePrefab, choiceList);
                   choice.title.text = c.Text;
                   choice.clickEvent.AddListener(_ctrl.SelectChoice);
               });
           });

           _ctrl.Events.End.AddListener(() => {
               speakerContainer.SetActive(false);
               ManagerScript.gm.setGameState(currGameState);
               foreach (Behaviour action in enableOnEnd) {
                    action.enabled = true;
               }
           });

           _ctrl.Events.NodeEnter.AddListener((node) => {
               //Debug.Log($"Node Enter: {node.GetType()} - {node.UniqueId}");
           });

           _ctrl.Play(dialogue, gameObjectOverrides.ToArray<IGameObjectOverride>());
           ManagerScript.gm.setGameState(GameState.DIALOGUE);
        }

        private void ClearChoices () {
            if (CurrShowTextRoutine != null) {
                StopCoroutine(CurrShowTextRoutine);
            }
            foreach (Transform child in choiceList) {
                Destroy(child.gameObject);
            }
        }

        private IEnumerator NextDialogue () {
            yield return null;

            while (!(Input.GetMouseButtonDown(0) && (CurrShowTextRoutine == null))) {
                yield return null;
            }

            _ctrl.Next();
        }

        private void Update () {
            // Required to run actions that may span multiple frames
            _ctrl.Tick();
        }

        private IEnumerator ShowText(string text) {
            System.Collections.Generic.Stack<int> endTagInfo = new System.Collections.Generic.Stack<int>();

            lines.text = "";
            int currIndex = 0;
            float timer = 0f; //Tracks the amount of time since the last character was printed
            float timeInterval = 0.02f; //The amount of time to wait between each character print

            yield return null; //Needed to delay routine from immediately showing all text
            while (lines.text.Length < text.Length) {

                //Check if mouse button is pressed, in which case show all the text immediately
                if (Input.GetMouseButtonDown(0)) {
                    lines.text = text;
                    yield return null; //Needed to delay NextDialogue from reading the same mouse click
                    break;
                }
                //Check if the innermost end tag has been reached
                while (endTagInfo.TryPeek(out int result)) {
                    if (result == currIndex) {
                        //Skip over ending tag
                        endTagInfo.Pop();
                        currIndex = endTagInfo.Pop();
                        //Go through the loop again in case we were placed at another ending tag
                    }
                    else {
                        //Don't need to jump
                        break;
                    }
                }

                //Check if there are text tags to insert/manage
                while (ManageTextTags(text, ref currIndex, endTagInfo)) {
                    //Tags were found, the indexes of the ending tag's start and end
                    //were stored in endTagInfo to skip over later
                    //Successful tag detection means the text should be checked again for another pair of inner tags
                }

                //At this point currIndex is not the index of a valid pair of tags

                //Text should only appear at a certain time rate independent of frame rate,
                //But the current method still needs to be called each frame
                timer += Time.deltaTime;
                if (timer >= timeInterval) {
                    lines.text = lines.text.Insert(currIndex, (text[currIndex]).ToString());
                    currIndex += 1;
                    timer = 0f;
                }
                yield return null;
            }
            lines.text = text; //Just in case
            CurrShowTextRoutine = null;
            yield break;
        }

        //Note: This method assumes all tags in the text are valid and would appear correctly if displayed immediately
        private bool ManageTextTags(string text, ref int currIndex, System.Collections.Generic.Stack<int> endTagInfo) {
            
            //Ensure that a tag is found
            if (text[currIndex] != '<') {
                return false;
            }
            int startOfStartTagIndex = currIndex;
            int endOfStartTagIndex = text.IndexOf('>', startOfStartTagIndex);
            if (endOfStartTagIndex == -1) {
                return false;
            }
            //Beginning and end of this tag found... but if it's actually
            //an ending tag, it should be

            //Beginning and end of starting tag found
            //Find beginning and end of corresponding ending tag

            int startOfEndTagIndex;
            int endOfEndTagIndex;
            int i = endOfStartTagIndex;
            int depth = 1;
            while ((depth > 0) && (i + 1 < text.Length)) {
                i += 1;
                if (text[i] == '<') {
                    if (text[i+1] == '/') {
                        //An ending tag is found
                        depth -= 1;
                    }
                    else {
                        //Another starting tag is found
                        depth += 1;
                    }
                }
            }
            if (i + 1 >= text.Length) {
                //Invalid tags
                return false;
            }

            //i is the start of the ending tag
            startOfEndTagIndex = i;
            endOfEndTagIndex = text.IndexOf('>', startOfEndTagIndex);
            if (endOfEndTagIndex == -1) {
                //Invalid tags
                return false;
            }

            //Grab the tags themselves
            string startTag = text.Substring(startOfStartTagIndex, endOfStartTagIndex - startOfStartTagIndex + 1);
            string endTag = text.Substring(startOfEndTagIndex, endOfEndTagIndex - startOfEndTagIndex + 1);

            //Insert the tags into lines.text
            lines.text = lines.text.Insert(startOfStartTagIndex, startTag + endTag);
            //Modify currIndex to start inserting the visible chars
            currIndex = endOfStartTagIndex + 1;
            //Add values to end of endTagInfo so calling method can skip over end tag
            endTagInfo.Push(endOfEndTagIndex + 1); //Index to jump to
            endTagInfo.Push(startOfEndTagIndex); //Index to jump from
            return true; //Successful tag detection
        } 
    }
}