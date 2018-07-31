using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartDialogue : MonoBehaviour {

    public bool started = false;
    public Button startButton;
    
    private string[] startDialogue = { "Về đến nhà rồi. Mình cùng ôn lại một bài học nhé." };

    public ArrayList questionlist = new ArrayList();
    private string[] question1 = { "Khi phát hiện đám cháy, bạn nên làm gì?" };
    private string[] question2 = { "Để thoát khỏi đám cháy bạn nên làm gì?" };
    private string[] question3 = { "Trong khi thoát khói đám cháy, bạn nên mang theo những đồ vật gì?" };
    private string[] question4 = { "Khi di chuyển trong đám cháy có nhiều khói, bạn nên làm gì?" };
    private string[] question5 = { "Số điện thoại gọi báo cháy là?" };

    private string[] rightAnswer = {
        "Hét thật to để cảnh báo mọi người",
        "Tìm lối thoát ra bên ngoài",
        "Không mang gì cả",
        "Bịt mũi và miệng bằng khăn ướt rồi bò ra ngoài",
        "114"
    };
    private string[] wrongAnswer = {
        "Cố gắng dập tăt đám cháy",
        "Chui vào trong tủ lạnh",
        "Tất cả những thứ có giá trị",
        "Lấy tay bịt miệng, thở bằng mũi và chạy ra ngoài",
        "113"
    };
    private string[] hint = {
        "Khi xảy ra hỏa hoạn, nếu chỉ có một mình bạn biết và cố gắng xử lý thì đám cháy có thể sẽ không ngừng lại mà tiếp tục lan ra, gây nguy hiểm cho bản thân bạn.",
        "Tủ lạnh chỉ có thể làm mát khi có điện. Khi hỏa hoạn xảy ra, hệ thống điện sẽ dễ bị ảnh hưởng gây cháy nổ. Như vậy khi bạn chui vào tủ lạnh sẽ rất nguy hiểm.",
        "Việc mang vác theo các đồ vật như đồ chơi, tiền, balo... sẽ khiến bạn khó di chuyển và bị mắc kẹt trong đám cháy lâu hơn, nguy hiểm đến tính mạng.",
        "Khi cháy, khói độc sẽ sinh ra bay lên cao. Khói này vô cùng độc hại, nếu hít phải bạn có thể bị ngạt thở trong đám cháy.",
        "Số cuối trong dãy số điện thoại cứu hỏa giống như hình ảnh con thuyền lướt trên mặt nước."
    };
    private int numberQuestions = 0;

    void Start () {
        questionlist.Add(question1);
        questionlist.Add(question2);
        questionlist.Add(question3);
        questionlist.Add(question4);
        questionlist.Add(question5);
	}
	
	// Update is called once per frame
	public void StartDialogue () {
        startButton.gameObject.SetActive(false);
        Dialogue dialogue = new Dialogue();

        dialogue.name = "Ken";
        dialogue.sentences = startDialogue;

        started = true;
        FindObjectOfType<DialogueManagerRoom>().StartDialogueRoom(dialogue);
	}

    public void NextQuestion(int number)
    {
        Dialogue dialogue = new Dialogue();

        dialogue.name = "Ken";
        dialogue.sentences = (string[]) questionlist[number];
        string right = rightAnswer[number];
        string wrong = wrongAnswer[number];
        string hintBox = hint[number];

        started = true;
        FindObjectOfType<DialogueManagerRoom>().StartDialogueRoom(dialogue, right, wrong, hintBox);
    }

}
