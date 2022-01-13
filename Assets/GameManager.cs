using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text popupText;
    public Text scoreText, missedText, timePerWord,totalEntry,WpmText,TotalTimeText;
    public InputField inputField, inputForTime;
    public string practicingWords;
    public bool startAnim;
    public string[] oneWords;
    public string[] twoWords;
    public string[] threeWords;
    public string[] fourWords;
    public string[] rightHand;
    public string[] leftHand;
    public int score, missed;
    public float time;
    bool firstTime;
    bool started = false;
    int entry;
    float TotalTime;
    float wpm;
    int color;
    public List<Color> colors;
    public bool isRightHand;
    public bool islefttHand;
    public float timeLimit;
    public InputField inputForPractice;
    public bool isPracticing;
    
    List<string> practicingWordsList = new List<string>();
    private void Start()
    {

        firstTime = false;

        score = 0;
        isPracticing = false;
        isRightHand = false;
        islefttHand = false;
        Camera.main.backgroundColor = colors[color];

        entry = 0;
        timeLimit = 1;
        timePerWord.text = "Time Per word: " + timeLimit.ToString();
        popupText.fontSize = 0;
        popupText.text = "";
        startAnim = false;
        oneWords = new string[]
        {
            "a",
"b",
"c",
"d",
"e",
"f",
"g",
"h",
"i",
"j",
"k",
"l",
"m",
"n",
"o",
"p",
"q",
"r",
"s",
"t",
"u",
"v",
"w",
"x",
"y",
"z"

        };
        twoWords = new string[] {"al",
"am",
"an",
"ar",
"as",
"at",
"aw",
"ax",
"ay",
"ba",
"be",
"bi",
"bo",
"by",
"ch",
"da",
"de",
"do",
"ed",
"ef",
"eh",
"el",
"em",
"en",
"er",
"es",
"et",
"ew",
"ex",
"fa",
"fe",
"gi",
"go",
"ha",
"he",
"hi",
"hm",
"ho",
"id",
"if",
"in",
"is",
"it",
"jo",
"ka",
"ki",
"la",
"li",
"lo",
"ma",
"me",
"mi",
"mm",
"mo",
"mu",
"my",
"na",
"ne",
"no",
"nu",
"od",
"oe",
"of",
"oh",
"oi",
"om",
"on",
"op",
"or",
"os",
"ow",
"ox",
"oy",
"pa",
"pe",
"pi",
"po",
"qi",
"re",
"sh",
"si",
"so",
"ta",
"te",
"ti",
"to",
"uh",
"um",
"un",
"up",
"us",
"ut",
"vu",
"we",
"wo",
"xi",
"xu",
"ya",
"ye",
"yo",
"za"
};
        fourWords = new string[] {

"zzzs",

"jazz",

"jizz",

"fizz",

"fuzz",

"hizz",

"wazz",

"bazz",

"buzz",

"mezz",

"mizz",

"mozz",

"muzz",

"pozz",

"gizz",

"jazy",

"lezz",

"quiz",

"razz",

"seqq",

"tizz",

"tuzz",

"zeze",

"hajj",

"jaxy",

"jynx",

"jeez",

"doxx",

"fiqh",

"fozy",

"hazy",

"vizy",

"waqf",

"whiz",

"zack",

"ziff",

"azym",

"cazh",

"chez",

"chiz",

"cozy",

"jeux",

"jinx",

"joky",

"juju",

"mazy",

"phiz",

"qoph",
"able",
"acid",
"aged",
"also",
"area",
"army",
"away",
"baby",
"back",
"ball",
"band",
"bank",
"base",
"bath",
"bear",
"beat",
"been",
"beer",
"bell",
"belt",
"best",
"bill",
"bird",
"blow",
"blue",
"boat",
"body",
"bomb",
"bond",
"bone",
"book",
"boom",
"born",
"boss",
"both",
"bowl",
"bulk",
"burn",
"bush",
"busy",
"call",
"calm",
"came",
"camp",
"card",
"care",
"case",
"cash",
"cast",
"cell",
"chat",
"chip",
"city",
"club",
"coal",
"coat",
"code",
"cold",
"come",
"cook",
"cool",
"cope",
"copy",
"CORE",
"cost",
"crew",
"crop",
"dark",
"data",
"date",
"dawn",
"days",
"dead",
"deal",
"dean",
"dear",
"debt",
"deep",
"deny",
"desk",
"dial",
"dick",
"diet",
"disc",
"disk",
"does",
"done",
"door",
"dose",
"down",
"draw",
"drew",
"drop",
"drug",
"dual",
"duke",
"dust",
"duty",
"each",
"earn",
"ease",
"east",
"easy",
"edge",
"else",
"even",
"ever",
"evil",
"exit",
"face",
"fact",
"fail",
"fair",
"fall",
"farm",
"fast",
"fate",
"fear",
"feed",
"feel",
"feet",
"fell",
"felt",
"file",
"fill",
"film",
"find",
"fine",
"fire",
"firm",
"fish",
"five",
"flat",
"flow",
"food",
"foot",
"ford",
"form",
"fort",
"four",
"free",
"from",
"fuel",
"full",
"fund",
"gain",
"game",
"gate",
"gave",
"gear",
"gene",
"gift",
"girl",
"give",
"glad",
"goal",
"goes",
"gold",
"Golf",
"gone",
"good",
"gray",
"grew",
"grey",
"grow",
"gulf",
"hair",
"half",
"hall",
"hand",
"hang",
"hard",
"harm",
"hate",
"have",
"head",
"hear",
"heat",
"held",
"hell",
"help",
"here",
"hero",
"high",
"hill",
"hire",
"hold",
"hole",
"holy",
"home",
"hope",
"host",
"hour",
"huge",
"hung",
"hunt",
"hurt",
"idea",
"inch",
"into",
"iron",
"item",
"jack",
"jane",
"jean",
"john",
"join",
"jump",
"jury",
"just",
"keen",
"keep",
"kent",
"kept",
"kick",
"kill",
"kind",
"king",
"knee",
"knew",
"know",
"lack",
"lady",
"laid",
"lake",
"land",
"lane",
"last",
"late",
"lead",
"left",
"less",
"life",
"lift",
"like",
"line",
"link",
"list",
"live",
"load",
"loan",
"lock",
"logo",
"long",
"look",
"lord",
"lose",
"loss",
"lost",
"love",
"luck",
"made",
"mail",
"main",
"make",
"male",
"many",
"Mark",
"mass",
"matt",
"meal",
"mean",
"meat",
"meet",
"menu",
"mere",
"mike",
"mile",
"milk",
"mill",
"mind",
"mine",
"miss",
"mode",
"mood",
"moon",
"more",
"most",
"move",
"much",
"must",
"name",
"navy",
"near",
"neck",
"need",
"news",
"next",
"nice",
"nick",
"nine",
"none",
"nose",
"note",
"okay",
"once",
"only",
"onto",
"open",
"oral",
"over",
"pace",
"pack",
"page",
"paid",
"pain",
"pair",
"palm",
"park",
"part",
"pass",
"past",
"path",
"peak",
"pick",
"pink",
"pipe",
"plan",
"play",
"plot",
"plug",
"plus",
"poll",
"pool",
"poor",
"port",
"post",
"pull",
"pure",
"push",
"race",
"rail",
"rain",
"rank",
"rare",
"rate",
"read",
"real",
"rear",
"rely",
"rent",
"rest",
"rice",
"rich",
"ride",
"ring",
"rise",
"risk",
"road",
"rock",
"role",
"roll",
"roof",
"room",
"root",
"rose",
"rule",
"rush",
"ruth",
"safe",
"said",
"sake",
"sale",
"salt",
"same",
"sand",
"save",
"seat",
"seed",
"seek",
"seem",
"seen",
"self",
"sell",
"send",
"sent",
"sept",
"ship",
"shop",
"shot",
"show",
"shut",
"sick",
"side",
"sign",
"site",
"size",
"skin",
"slip",
"slow",
"snow",
"soft",
"soil",
"sold",
"sole",
"some",
"song",
"soon",
"sort",
"soul",
"spot",
"star",
"stay",
"step",
"stop",
"such",
"suit",
"sure",
"take",
"tale",
"talk",
"tall",
"tank",
"tape",
"task",
"team",
"tech",
"tell",
"tend",
"term",
"test",
"text",
"than",
"that",
"them",
"then",
"they",
"thin",
"this",
"thus",
"till",
"time",
"tiny",
"told",
"toll",
"tone",
"tony",
"took",
"tool",
"tour",
"town",
"tree",
"trip",
"TRUE",
"tune",
"turn",
"twin",
"type",
"unit",
"upon",
"used",
"user",
"vary",
"vast",
"very",
"vice",
"view",
"vote",
"wage",
"wait",
"wake",
"walk",
"wall",
"want",
"ward",
"warm",
"wash",
"wave",
"ways",
"weak",
"wear",
"week",
"well",
"went",
"were",
"west",
"what",
"when",
"whom",
"wide",
"wife",
"wild",
"will",
"wind",
"wine",
"wing",
"wire",
"wise",
"wish",
"with",
"wood",
"word",
"wore",
"work",
"yard",
"yeah",
"year",
"your",
"zero",
"zone"
};
        threeWords = new string[] {"Ace",
"Aid",
"Aim",
"Air",
"Ale",
"Arm",
"Art",
"Awl",
"Eel",
"Ear",
"Era",
"Ice",
"Ire",
"Ilk",
"Oar",
"Oak",
"Oat",
"Oil",
"Ore",
"Owl",
"Urn",
"Web",
"Cab",
"Dab",
"Jab",
"Lab",
"Tab",
"Dad",
"Fad",
"Lad",
"Mad",
"Bag",
"Gag",
"Hag",
"Lag",
"Mag",
"Rag",
"Tag",
"Pal",
"Cam",
"Dam",
"Fam",
"Ham",
"Jam",
"Ram",
"Ban",
"Can",
"Fan",
"Man",
"Pan",
"Tan",
"Bap",
"Cap",
"Lap",
"Pap",
"Rap",
"Sap",
"Tap",
"Yap",
"Bar",
"Car",
"Jar",
"Tar",
"War",
"Bat",
"Cat",
"Hat",
"Mat",
"Pat",
"Tat",
"Rat",
"Vat",
"Caw",
"Jaw",
"Law",
"Maw",
"Paw",
"Bay",
"Cay",
"Day",
"Hay",
"Ray",
"Pay",
"Way",
"Max",
"Sax",
"Tax",
"Pea",
"Sea",
"Tea",
"Bed",
"Med",
"Leg",
"Peg",
"Bee",
"Lee",
"Tee",
"Gem",
"Bet",
"Jet",
"Net",
"Pet",
"Set",
"Den",
"Hen",
"Men",
"Pen",
"Ten",
"Yen",
"Dew",
"Mew",
"Pew",
"Bib",
"Fib",
"Jib",
"Rib",
"Sib",
"Bid",
"Kid",
"Lid",
"Vid",
"Tie",
"Lie",
"Pie",
"Fig",
"Jig",
"Pig",
"Rig",
"Wig",
"Dim",
"Bin",
"Din",
"Fin",
"Gin",
"Pin",
"Sin",
"Tin",
"Win",
"Yin",
"Dip",
"Lip",
"Pip",
"Sip",
"Tip",
"Git",
"Hit",
"Kit",
"Pit",
"Wit",
"Bod",
"Cod",
"God",
"Mod",
"Pod",
"Rod",
"Doe",
"Foe",
"Hoe",
"Roe",
"Toe",
"Bog",
"Cog",
"Dog",
"Fog",
"Hog",
"Jog",
"Log",
"Poi",
"Con",
"Son",
"Ton",
"Zoo",
"Cop",
"Hop",
"Mop",
"Pop",
"Top",
"Bot",
"Cot",
"Dot",
"Lot",
"Pot",
"Tot",
"Bow",
"Cow",
"Sow",
"Row",
"Box",
"Lox",
"Pox",
"Boy",
"Soy",
"Toy",
"Cub",
"Nub",
"Pub",
"Sub",
"Tub",
"Bug",
"Hug",
"Jug",
"Mug",
"Rug",
"Tug",
"Bum",
"Gum",
"Hum",
"Rum",
"Tum",
"Bun",
"Gun",
"Pun",
"Run",
"Sun",
"Cup",
"Pup",
"Cut",
"Gut",
"Hut",
"Nut",
"Rut",
"Egg",
"Ego",
"Elf",
"Elm",
"Emu",
"End",
"Eve",
"Eye",
"Ink",
"Inn",
"Ion",
"Ivy",
"Lye",
"Dye",
"Rye",
"Pus",
"Gym",
"Add",
"Ail",
"Are",
"Eat",
"Err",
"Use",
"Nab",
"Nag",
"Sag",
"Wag",
"Ran",
"Nap",
"Mar",
"Has",
"Was",
"Sat",
"Lay",
"Say",
"Fed",
"See",
"Get",
"Let",
"Met",
"Wet",
"Sew",
"Boo",
"Coo",
"Moo",
"Bop",
"Lop",
"Sop",
"Mow",
"Tow",
"Dub",
"Rub",
"Dug",
"Lug",
"Sup",
"Buy",
"Got",
"Jot",
"Rot",
"Nod",
"Hem",
"Led",
"Wed",
"Did",
"Dig",
"Nip",
"Rip",
"Zip",
"Bit",
"Sit",
"Won",
"Pry",
"Try",
"Cry",
"All",
"Fab",
"Bad",
"Had",
"Rad",
"Tad",
"Far",
"Fat",
"Raw",
"Lax",
"Gay",
"Big",
"Fit",
"Red",
"Old",
"New",
"Hot",
"Coy",
"Fun",
"Ill",
"Odd",
"Shy",
"Dry",
"Wry",
"Bam",
"Nah",
"Yea",
"Yep",
"Naw",
"Hey",
"Yay",
"Nay",
"Pow",
"Wow",
"Bye",
"Yum",
"Ugh",
"Bah",
"Umm",
"Why",
"Aha",
"Aye",
"Hmm",
"Hah",
"Huh",
"Ssh",
"Brr",
"Heh",
"Oop",
"Oof",
"Zzz",
"Gee",
"Grr",
"Yup",
"Gah",
"Mmm",
"Dag",
"Arr",
"Eww",
"Ehh",
};
        rightHand = new string[]
        {
            "y","u","i","o","p","[","]","h","j","k","l",";","'","n","m",",",".","/"
        };
        leftHand = new string[]
        {
            "q","w","e","r","t","a","s","d","f","g","z","x","c","v","b"
        };



   }
    void Update()
    {

        
        if (startAnim)
        {
            StartCoroutine(Delay1());
        }
        if (Input.GetKeyDown(KeyCode.Space) && !firstTime)
        {
            SetText();
            firstTime = true;
        }
        if (firstTime)
        {
            started = true;
            time += Time.deltaTime;
            
            
        }
        if (started)
        {
            TotalTime += Time.deltaTime;
            TotalTimeText.text = "Total Time : " + TotalTime.ToString().Substring(0, 3);
            wpm = (entry * 60) / TotalTime;
            WpmText.text = "WPM : " + wpm;
        }
        if (time > timeLimit)
        {
            SetText();
            Missed();
        }
    }

    public void SetRightHand()
    {

        if (!isRightHand)
        {

        isRightHand = true;
        }
        else
        {
            isRightHand = false;

        }

    }
    public void SetLeftHand()
    {

        if (!islefttHand)
        {

            islefttHand = true;
        }
        else
        {
            islefttHand = false;

        }

    }
    public void SetText()
    {

        time = 0;

        if (!isRightHand && !islefttHand && !isPracticing)
        {
            var indexOfThreeWords = Random.Range(0, threeWords.Length);
            var indexOfFourWords = Random.Range(0, fourWords.Length);
            var indexOfOneWords = Random.Range(0, oneWords.Length);
            var indexOfTwoWords = Random.Range(0, twoWords.Length);

            if (score < 10)
            {
                popupText.text = oneWords[indexOfOneWords].ToLower();

            }

            else if (score < 20)
            {
                popupText.text = twoWords[indexOfTwoWords].ToLower();

            }
            else if (score < 30)
            {
                popupText.text = threeWords[indexOfThreeWords].ToLower();

            }
            else if (score < 50)
            {
                popupText.text = fourWords[indexOfFourWords].ToLower();

            }
            else if(score <65)
            {
                popupText.text = fourWords[indexOfFourWords].ToLower()+oneWords[indexOfOneWords].ToLower();
            }
            else if (score < 80)
            {
                popupText.text = fourWords[indexOfFourWords].ToLower() + twoWords[indexOfTwoWords].ToLower(); ;
            }
            else if (score < 100)
            {
                popupText.text = fourWords[indexOfFourWords].ToLower() +threeWords[indexOfThreeWords].ToLower();

            }


            startAnim = true;
            inputField.ActivateInputField();
            Animation();
            firstTime = true;
        }
        else if (isRightHand && !islefttHand && !isPracticing)
        {
            var a =rightHand[ Random.Range(0, rightHand.Length)];
            var b = rightHand[Random.Range(0, rightHand.Length)];
            var c = rightHand[Random.Range(0, rightHand.Length)];
            var d = rightHand[Random.Range(0, rightHand.Length)];

            if (score<15)
            {
                popupText.text = (a);
            }
            else if (score < 30)
            {
                popupText.text = (a + b);
            }
            else if (score < 45)
            {
                popupText.text = (a + b + c);
            }
            else if (score < 60)
            {
                popupText.text = (a + b + c + d);
            }



            startAnim = true;
            inputField.ActivateInputField();
            Animation();
            firstTime = true;


        }
        else if (islefttHand && !isRightHand && !isPracticing)
        {
            var a = leftHand[Random.Range(0, leftHand.Length)];
            var b = leftHand[Random.Range(0, leftHand.Length)];
            var c = leftHand[Random.Range(0, leftHand.Length)];
            var d = leftHand[Random.Range(0, leftHand.Length)];
            if (score < 15)
            {
                popupText.text = (a);
            }
            else if (score < 30)
            {
                popupText.text = (a + b);
            }
            else if (score < 45)
            {
                popupText.text = (a + b + c);
            }
            else if (score < 60)
            {
                popupText.text = (a + b + c + d);
            }
            else
            {
                popupText.text = (a + b + c + d);
            }
            



            startAnim = true;
            inputField.ActivateInputField();
            Animation();
            firstTime = true;

        }
        else if (isPracticing && !islefttHand && !isRightHand)
        {
            

            
            startAnim = true;
            inputField.ActivateInputField();
            Animation();
            firstTime = true;


        }
        


    }
    public void PracticingWordsSetting()
    {
        practicingWords = inputForPractice.text;
        
        
    }
    public void Animation()
    {

        if (popupText.fontSize != 110)
        {
            popupText.fontSize += 5;
            time = 0;
        }
    }
    public void TextChecking()
    {
        if (inputField.text == popupText.text)
        {
            entry += popupText.text.Length;
            totalEntry.text = "Total Letters Typed : " + entry;
            score += 1;
            scoreText.text = "Score : " + score;
            ResetText();
            SetText();
            ColorChange();
        }
    }
    public void Missed()
    {
        missed += 1;
        missedText.text = "Missed : " + missed.ToString();
        inputField.text = "";
        Camera.main.backgroundColor = Color.red;
        color = 0;


    }
    public void ResetText()
    {
        popupText.fontSize = 0;
        popupText.text = " ";
        inputField.text = "";
    }
    public IEnumerator Delay1()
    {
        yield return new WaitForSeconds(0.1f);
        Animation();
    }
    public void SetTimeLimit()
    {
        timeLimit = float.Parse(inputForTime.text);
        if (timeLimit > 20)
        {
            return;
        }
        timePerWord.text = timeLimit.ToString();
        timePerWord.text = "Time Per Word: " + timeLimit.ToString();

    }
    public void ColorChange()
    {
        if (color == colors.Count)
        {
            color = 0;

        }
        Camera.main.backgroundColor = colors[color];
        color += 1;
    }
    public void SceneReload()
    {
        SceneManager.LoadScene(0);
    }
    public void PracticeWordSettingToggle()
    {
        if (isPracticing)
        {
            isPracticing = false;
        }
        else
        {
            isPracticing = true;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

}
