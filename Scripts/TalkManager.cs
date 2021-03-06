using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    private Dictionary<int, string[]> dialogue;
    private Dictionary<int, Sprite> portData;
    public Sprite[] portArr; 
    
    void Start()
    {
        dialogue = new Dictionary<int, string[]>();
        portData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //디폴트 대사(해당 오브젝트에 퀘스트 대사가 없을 때 출력되는 대사들)
        dialogue.Add(1000, new string[] {"집에서 로봇 군이 걱정하고 있을 텐데~..#0"});//에이
        dialogue.Add(1100, new string[] {"으윽...집에 가고 싶어.......#3"});//루퍼트
        dialogue.Add(1200, new string[] {".........Zzz...#1"});//엔젤
        dialogue.Add(100, new string[]{
            "상자다.",
            "...이런 것까지 일일히 대화창 띄울 필요 있어?"});
        dialogue.Add(200, new string[]{
            "책상이다. 위에 뭐라고 쓰여 있지만, 굉장한 악필이다.",
            "전혀 읽을 수가 없다..",
            "..하지만, 왜 책상이 밖에 있는 걸까..?"});
        dialogue.Add(201, new string[]{
            "저번에 본 책상과 같은 책상이다.",
            "위에 있는 종이에 뭐라고 쓰여 있다.\n호수 조사 결과: 수심-확인 불가능, 면적-약 286제곱미터.",
            "..하지만, 누가 자꾸 책상을 밖에 두는 걸까?"});//작동안함
        dialogue.Add(202, new string[] {
            "또 책상이다.",
            "뭐라고 쓰여 있다..\n\"이 위로는 산악 지대. 올라갈 수 없었음..\"",
            "높이 약 7~8미터."});//작동안함
        dialogue.Add(400, new string[] {
            "...........................",
            "헉",
            "131ca09",
            "%uAD6D%uBBFC%20dfbb1-1-712f3",
            "%uACE0%uB9C8%uC6CC%uC694"
        });
        dialogue.Add(500, new string[] {
            ""
        });

        //첫번째 퀘스트(모두와 이야기 나누기) 대화
        dialogue.Add( 10 + 1000, new string[] {
            "안녕하세요!#2",
            "혹시 당신도 이곳으로 갑자기 날려온 사람인가요?#0",
            "내 이름은 에이.\n28살 독신!#2",
            "혹시 왜 여기로 오신 건지는 알고 계신가요?#0",
            "...흠, 당신도 이곳으로 날려온 이유는 모르는건가요..#1",
            "그래도 일단, 당신도 이곳에서 나가는 게 목적이죠?#0",
            "그렇다면 일단 여기 있는 사람들하고\n한번씩 이야기를 나눠 보는 건 어때요?#2"
        });
        dialogue.Add( 11 + 1100, new string[] {
            ".........으으........#3",
            "집에 가고 싶어...여기 어디야.......#3",
            "........으앗!?#2",
            "까...깜짝이야..! 다...당신은 누구예요...!?#2",
            "..............#2",
            ".....으윽.... 제...제 이름은 루퍼트...\n15살....나이는 왜 알려줘야 하는 거지..?#1",
            "...으..집에 갈래...이상한 사람도 있고.. 무서워...#3"
        } );
        dialogue.Add( 12 + 1200, new string[] {
            ".............#1",
            "........앗, 깜짝이야.. 뭐야?#0",
            "여기가 어딘 지 아냐고?...\n.....모르는데.#2",
            "...........내 소개...?#2",
            "...굳이 말해야 하나....#3",
            "나는.. 공안 직속 계약 악마인.. 천사의 악마.\n정신 차리니까 여기에 있었어..#0",
            ".....돌아가지 않아도 괜찮냐고?#2",
            "몰라... 데빌 헌터 같은 거 하고 싶지 않고..\n일하지 않아도 된다면 여기 쭉 있어도 상관없어..#2",
            ".........왜 계속 쳐다보는거야...?#3",
            "...뭐 시킬 거 없냐고....? ....모르겠거든...\n...저쪽에 호수 하나 있던데, 거기라도 가 보던가..#3"
        } );
        
        //두번째 퀘스트(호수 조사하기) 대화
        dialogue.Add( 20 + 1000, new string[]{//0
            "어때요? 모두와 좀 친해진 것 같아요?#2",
            "음, 천사가 호수를 조사해달라고 했다고요?#0",
            "...그런데 이 곳에 대해선 관심없어 보인다구요..?#1",
            "헤에.. 왜 호수를 조사해달라고 한 걸까....#0",
            "뭐 아무튼, 그럼 호수에 한번 가 보는 건 어때요?#2"
        } );
        dialogue.Add( 20 + 300, new string[] {//1
            "..이건 뭐지? 이상하게 생긴 물건을 주웠다."
        } );
        dialogue.Add( 21 + 1000, new string[] {//2
            "뭔가 찾으신 건 있나요?#0",
            "이건.....#0",
            "어라? 이거 내 측정기잖아요!\n바다나 호수의 넓이를 혼자서 재려고 만들었던 건데..#2",
            "왠지 갑자기 없어졌더라니...\n설마 여기로 날아왔던 거라곤 상상도 못했네요!#2",
            "이걸로 우리도 이 세계와 전혀 관련이 없는 것은\n아니라는 게 증명되었네요!#2",
            "그런데, 참 이상하네요....내 면적 측정기가\n왜 하필 이곳 호수 근처에서 발견된걸까요?#0",
            "꼭 누군가 호수의 면적을 측정하기라도 한 것처럼..#0"
        } );
        
        //세번째 퀘스트(산 조사하기) 대화
        dialogue.Add( 30 + 1000, new string[] {//시작 대화(0)
            "음... 내 예상이 맞다면, 여기 있는 사람들은..#0",
            "원래 세계에서 뭔가를 잃어버렸다는 공통점이\n있는 것 같은데요,#0",
            "루 군운 혹시..\n 뭔가 최근에 잃어버린 물건 같은 거 없나요?#0",
            "으음...잘 기억 안 나는데.......#100",
            "으음.....으으....................앗!\n그러고보면.. 잃어버린 게 있었던 것 같기도..#100",
            "오오! 뭔데요?#2",
            "...................#101",
            "으으...역시 기억 안 나요.......#103",
            "...........#0",
            "저런.#1",
            "음, 그럼.....\n그쪽의.. 그러니까.. 천사 씨는 어때요?#0",
            "................#201",
            "................#0",
            "..얘는 글러먹었네.#2",
            "에휴....써먹을 만한 사람은 나하고 당신뿐이겠네요.#1",
            "일단 나는 이쪽을 좀 둘러볼테니, 당신은 여기서\n북쪽으로 가면 보이는 산을 조사해주세요.#0",
            "..나는 몸이 약한 편이라, 못 올라갈 것 같거든요.\n뭔가 발견할 수 있으면 좋겠네요!#2"
        } );
        dialogue.Add( 31 + 500, new string[] {//깃털 조사(1)
            "깃털이 떨어져있다...\n새가 날아가다 떨어뜨린 걸까?",
            "하지만 이 근처에서 우리 이외의 생명체는 본 적이 없다.",
            "깃털을 잃어버릴 만한 사람이 있었나..?"
        } );
        dialogue.Add( 32 + 600, new string[] {//종이 조사(2)
            "종이가 떨어져있다.",
            "엄청난 악필이라 전혀 읽을 수가 없다..",
            "책상 위에 글을 쓴 사람이랑 같은 사람이 쓴 것 같다."
        } );
        dialogue.Add( 33 + 1200, new string[] {//조사 보고(3)
            ".................#1",
            ".............또 뭐야?#2",
            "......뭐? 깃털?\n..내 거 아니냐고?#0",
            "음....으응.......확실히..\n내 거인거 같기도 하고.....#2",
            "..근데 그게 왜 너한테서 나오는 거야?\n....산에서 주웠다고?#3",
            "..........??#2"
        } );
        
        //에이
        portData.Add( 1000+0, portArr[0] );
        portData.Add( 1000+1, portArr[1] );
        portData.Add( 1000+2, portArr[2] );
        portData.Add( 1000+3, portArr[3] );
        
        //루퍼트
        portData.Add( 1100+0, portArr[4] );
        portData.Add( 1100+1, portArr[5] );
        portData.Add( 1100+2, portArr[6] );
        portData.Add( 1100+3, portArr[7] );
        
        //엔젤
        portData.Add( 1200+0, portArr[8] );
        portData.Add( 1200+1, portArr[9] );
        portData.Add( 1200+2, portArr[10] );
        portData.Add( 1200+3, portArr[11] );
    }

    public string GetTalk( int id, int talkIndex )
    {
        //진행중인 퀘스트에서 해당 NPC의 대사가 없을 때
        //해당 퀘스트에서의 맨 처음 대사를 가지고 옴
        //*그렇기 때문에 이렇게만 하려면 모든 NPC가 한 막(한 퀘스트)에서 최소 대사 하나씩은 가지고있어야 함.
        //*그렇지 않을 경우 아래의 디폴트 대사가 출력됨.
        if (!dialogue.ContainsKey(id)){//ContainsKey: 해당 딕셔너리에 념겨준 키가 존재하는지 확인
//            if (!dialogue.ContainsKey(id - id % 10)) 
                return GetTalk(id - id % 100, talkIndex);//퀘스트 맨 처음 대사도 존재하지 않을 때(디폴트 대사 출력)
//            else    **나는 무조건 기본 대사만 출력하게 하고 싶어서 주석처리함.**
//                return GetTalk(id - id % 10, talkIndex); //해당 퀘스트의 첫 번째 대사가 존재하고, 현재 진행도에 관련된 대사는 없을 때
        }
        if (talkIndex == dialogue[id].Length) //넘겨받은 인덱스가 전체 길이와 같을 때(데이터가 더 이상 없을 때)
            return null;
        else
            return dialogue[id][talkIndex];
    }

    public Sprite GetPortrait( int id, int portIndex )
    {
        return portData[id + portIndex];
    }
}
