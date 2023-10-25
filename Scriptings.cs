
// import System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using c0_4unity_chessname;
// import c0_4unity_chess;

// // This is the main scripting part...
public class Scriptings : MonoBehaviour
{
    public bool showButton = true;
    // var Name = "Various javascripts";
    public string Name = "Various javascripts";
    public bool LandingP = false;
    public bool FirstStart = true;
    // Animation /or fastest visual performance by redrawing...
    public bool drawAnim = true;
    // var toPromote = 0;						// Promotion option (0-Q,1-R,2-B,3-N)...
    public int toPromote = 0;
    // var drag1_at = "";								// square with a piece dragged after the first drag...
    // var drag1_animator: int = 0;						// On drag start animation -counter
    public string drag1_at = "";
    public string at = "";
    public int drag1_animator = 0;
    // var move_animator: int = 2;					// Animation counter when a piece is moving...
    public int move_animator = 2;
    // var mouse_at = "";							// Keeps last mouse square at... (just for legal moves suggestion by using particle)
    public string mouse_at = "";
    // var message2show = "";						// Message to show on GUI
    // var engineStatus = 0;
    public string answer_plane = "";                 //Leo 回棋的坐标
    public string message2show = "";

    public int engineStatus = 0;
    // var gameover = false;						// is true when the game is over...
    public bool gameover = false;
    // var TakeBackFlag = false;					// true on takeback-button was pressed...
    public bool TakeBackFlag = false;
    // var NewGameFlag = false;					// true on new game-button was pressed...
    public bool NewGameFlag = false;
    // var LanguageFlag = false;
    public bool LanguageFlag = false;
    public int chess_strength = 1;
    public int mode = 0;
    public bool setCamSide = true;
    public bool setCamSide2 = false;
    c0_4unity_chess C0 = new c0_4unity_chess();

    // var StockfishAccessible = false;			// Script sets true on Stockfish is accessible...
    // var useStockfish = true;					// toggled by user if use...
    public bool useStockfish = true;
    public bool StockfishAccessible = false;
    public bool english = true;
    public bool finnish = false;
    public bool irish = false;
    public bool koreanish = false;
    // // GUI interface on screen...
    // var lang_flag = 0; //default 0 English, 1 Irish, 2 Finnish, 3 Koreanish
    public int lang_flag = 0;
    // var promo2Queen = true;
    public bool promo2Queen = true;
    public bool promo2Rook = false;
    public bool promo2Bishop = false;
    public bool promo2Knight = false;




    // var menuArr =
    //     [
    //         ["English", "新游戏", "悔棋", "Animation", "Top Camera", "Side Camera", "Brightness", "Promotion", "Pawn", "Rook", "Bishop", "Knight", "Queen", "请走棋...", "思考中...", "Language", "English", "Irish", "Finnish", "Korean", "将军!", "黑方走棋", "白方走棋", "离开游戏", "Set Mode", "确定"],
    //         ["Gaeilge", "Cluiche Nua", "Tóg ar Ais", "Beochan", "Ceamara Barr", "Ceamara Taobh", "Gile", "Uasghrádú", "Ceitheranach", "Caisléan", "Easpag", "Ridire", "Banríon", "Do Imirt...", "Ag Ríomh...", "Teanga", "Bearla", "Gaeilge", "Fionlainnis", "Cóiréis", "Seiceáil!!!", "Dubh Imirt", "Bán Imirt", "Scoir", "Athraigh Mód", "Maith"],
    //         ["Suomi", "Uusi Peli", "Kumoa", "Animaatiot", "Yläkamera", "Sivukamera", "Kirkkaus", "Korottuminen", "Sotilas", "Torni", "Lähetti", "Hevonen", "Kuningatar", "Sinun Vuorosi...", "Lasketaan...", "Kieli", "Englanti", "Irlanti", "Suomi", "Korea", "shakki!!!", "mustan vuoro", "valkoisen vuoro", "Poistu pelistä", "Valitse pelimuoto", "OK"],
    //         ["한국어", "새 게임", "한 수 무르기", "애니메이션", "위에서 보기", "옆에서 보기", "조명", "프로모션", "폰", "룩", "비숍", "나이트", "퀸", "플레이어 차례..."/*13*/, "계산 중...", "언어"/*15*/, "영어", "아일랜드어", "핀란드어", "한국어", "체크!!!"/*20*/, "검은색 차례", "흰색 차례", "게임 종료"/*23*/, "모드 설정", "확인"]
    //     ];
    // //String Array for Menu
    string[,] menuArr = new string[4, 26]{
        {"English", "新游戏", "悔棋", "Animation", "Top Camera", "Side Camera", "Brightness", "Promotion", "Pawn", "Rook", "Bishop", "Knight", "Queen", "请走棋...", "思考中...", "Language", "English", "Irish", "Finnish", "Korean", "将军!", "黑方走棋", "白方走棋", "离开游戏", "Set Mode", "确定" },
        {"English", "新游戏", "悔棋", "Animation", "Top Camera", "Side Camera", "Brightness", "Promotion", "Pawn", "Rook", "Bishop", "Knight", "Queen", "请走棋...", "思考中...", "Language", "English", "Irish", "Finnish", "Korean", "将军!", "黑方走棋", "白方走棋", "离开游戏", "Set Mode", "确定" },
        {"English", "新游戏", "悔棋", "Animation", "Top Camera", "Side Camera", "Brightness", "Promotion", "Pawn", "Rook", "Bishop", "Knight", "Queen", "请走棋...", "思考中...", "Language", "English", "Irish", "Finnish", "Korean", "将军!", "黑方走棋", "白方走棋", "离开游戏", "Set Mode", "确定" },
        {"English", "新游戏", "悔棋", "Animation", "Top Camera", "Side Camera", "Brightness", "Promotion", "Pawn", "Rook", "Bishop", "Knight", "Queen", "请走棋...", "思考中...", "Language", "English", "Irish", "Finnish", "Korean", "将军!", "黑方走棋", "白方走棋", "离开游戏", "Set Mode", "确定" }
    };

    public string white = "w";
    public string black = "b";
    public string temp = "";
    public bool restart = false;
    public bool quit = false;
    public bool alert = false;
    public bool hide = false;

    public bool setMeOnly()
    {
        english = finnish = irish = koreanish = false;
        return true;
    }

    public bool setMeOnly2()
    {
        promo2Queen = promo2Rook = promo2Bishop = promo2Knight = false;
        return true;
    }

    public void OnGUI()
    {

        Event e = Event.current;
        //       // Create style for a button
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = Screen.width / 20;
        // Load and set Font
        Font myFont = (Font)Resources.Load("Fonts/DroidSansFallback", typeof(Font));
        myButtonStyle.font = myFont;

        GUIStyle myButtonStyle2 = new GUIStyle(GUI.skin.button);
        myButtonStyle2.fontSize = Screen.width / 20;
        myButtonStyle2.font = myFont;


        if (LandingP)
        {
            if (FirstStart)
            {

                //   mode = 1;
            }

            else
            {

                // Set color for selected and unselected buttons
                GUI.skin.box.fontSize = Screen.width / 20;
                GUI.skin.button.fontSize = Screen.width / 20;
                GUI.skin.box.alignment = TextAnchor.MiddleCenter;
                //         // show message;
                //message info window
                GUI.Box(new Rect(((Screen.width - Screen.width / 4) / 2), (Screen.height / 4), (Screen.width / 4), (Screen.width / 10)), message2show, myButtonStyle);
                if (engineStatus == 1) { engineStatus = 2; }
                if (GUI.Button(new Rect(((Screen.width - Screen.width / 4) / 2 - Screen.width / 4), (Screen.height - Screen.width / 10 * 2), (Screen.width / 4), (Screen.width / 10)), menuArr[lang_flag, 2], myButtonStyle)) TakeBackFlag = true;
                if (GUI.Button(new Rect(((Screen.width - Screen.width / 4) / 2 + Screen.width / 4), (Screen.height - Screen.width / 10 * 2), (Screen.width / 4), (Screen.width / 10)), menuArr[lang_flag, 1], myButtonStyle)) NewGameFlag = true;
                if (mode == 1)
                {
                }
                if (alert && hide)
                {
                    GUI.Box(new Rect((Screen.width - Screen.width / 4) / 2, (Screen.height - Screen.height / 10) / 2, Screen.width / 4, Screen.width / 10), menuArr[lang_flag, 20]);

                    if (GUI.Button(new Rect((Screen.width - Screen.width / 4) / 2, (Screen.height - Screen.height / 10) / 2 + Screen.width / 10, Screen.width / 4, Screen.width / 10), menuArr[lang_flag, 25])) { hide = false; }


                }
                if (gameover)
                {
                    if (GUI.Button(new Rect((Screen.width - Screen.width / 4) / 2, (Screen.height - Screen.height / 10) / 2 + Screen.width / 10, Screen.width / 4, Screen.width / 10), menuArr[lang_flag, 1])) { NewGameFlag = true; }

                }
            }
        }
        if (showButton)
        {
            var c1 = (GameObject.Find("CameraSide")).GetComponent<Camera>();
            var c2 = (GameObject.Find("CameraSide2")).GetComponent<Camera>();
            c1.enabled = false;
            c2.enabled = false;
            if (GUI.Button(new Rect(((Screen.width - Screen.width / 4) / 2), (Screen.height / 4), (Screen.width / 4), (Screen.width / 10)), "开始游戏", myButtonStyle2)) { LandingP = true; showButton = false; ActivateCamera(true); mode = 1; }
            if (GUI.Button(new Rect(((Screen.width - Screen.width / 4) / 2), (Screen.height / 4 + Screen.width / 10), (Screen.width / 4), (Screen.width / 10)), "单机双人", myButtonStyle2)) { LandingP = true; showButton = false; ActivateCamera(true); mode = 2; }

        }
    }

    public void Start()
    {

        GameObject.Find("Script2").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Script6").GetComponent<Renderer>().enabled = false;
        if (LandingP)
        {
            ActivateCamera(true);
        }


    }
    void Update()
    {

        if (LandingP)
        {

            if (restart)
            {
                Application.LoadLevel(0);
            }
            if (quit)
            {
                Application.Quit();
            }

            if (!C0.c0_moving) ActivateCamera(false);

            //     if (FirstStart) {// could be right in Start(), anyway it's the same..., sometimes good to wait a bit while all the objects are being created...		
            if (FirstStart)
            {


                //         if (mode == 1 || mode == 2) {
                if (mode == 1 || mode == 2)
                {
                    //             PlanesOnBoard();					// Planes needed for mouse drag... (a ray from camera to this rigibody object is catched)...
                    PlanesOnBoard();

                    TransformVisualAllToH1();       // The board contains blank-pieces (to clone from) just on some squares. Moving all of them to h1... 

                    //             C0.c0_side = 1;							// This side is white.   For black set -1
                    C0.c0_side = 1;
                    //             C0.c0_waitmove = true;					// Waiting for mouse drag...
                    C0.c0_waitmove = true;
                    //             C0.c0_set_start_position("");		// Set the initial position... 
                    C0.c0_set_start_position("");
                    //         }
                }
                //     }
            }

            //     DoPieceMovements();							// All the movements of pieces (constant frames per second for rigidbody x,y,z)...
            DoPieceMovements();
            //     if (mode == 1) DoEngineMovements();							// If chess engine should do a move...
            if (mode == 1) DoEngineMovements();
            //    
            else if (mode == 2) StartCoroutine(checkGameover());
            //     MouseMovement();								// Mouse movement events, suggest legal moves...
            MouseMovement();
            //     RollBackAction();	
            //RollBackAction();								// If a takeback should be performed/ or new game started..

            RollBackAction();
            //     if (FirstStart) {
            if (FirstStart)
            {
                //2022_10_26 Leo delay time to run first

                //         position2board();					// Set current position on the board visually...
                //2022_10_26 Leo delay function


                //2022_10_26 end
                position2board();

                //         HideBlankPieces();					// Hide blank-pieces...
                HideBlankPieces();
                if (mode == 1 || mode == 2)
                {
                    FirstStart = false;
                }
            }
            else
            {
                //         DragDetect();						// If mouse pressed on any square...
                DragDetect();
                //     }
            }
        }
    }

    public void ActivateCamera(bool first)
    {
        var c1 = (GameObject.Find("CameraSide")).GetComponent<Camera>();
        var c2 = (GameObject.Find("CameraSide2")).GetComponent<Camera>();
        if (first)
        {
            c2.enabled = setCamSide2;
            c1.enabled = setCamSide;
        }
        else
        {


            if (mode == 2)
            {

                if ((!c1.enabled) && setCamSide && white == "w") { setCamSide2 = false; c1.enabled = true; c2.enabled = false; }
                if ((!c2.enabled) && setCamSide2 && white != "w") { setCamSide = false; c2.enabled = true; c1.enabled = false; }
            }
        }
    }


    string Revert_at(string ats)
    {
        var horiz = System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + (System.Convert.ToInt32("h"[0]) - System.Convert.ToInt32(ats[0])));
        var vert = (9 - System.Convert.ToInt32(ats.Substring(1, 1))).ToString();
        return horiz + vert;
        // }
    }

    void MouseMovement()
    {
        if ((drag1_at.Length == 0) || C0.c0_moving || ((mouse_at.Length > 0) && (!(drag1_at == mouse_at))))
        {

            // Debug.Log(drag1_at);
            //         mouse_at = "";
            mouse_at = "";
            //     }
        }
        //     if ((drag1_at.Length > 0) && (!C0.c0_moving)) {
        if ((drag1_at.Length > 0) && (!C0.c0_moving))
        {
            //         // We need to actually hit an object
            //         var hit: RaycastHit;

            //Debug.Log("RaycastHit");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("ray:"+ray);
            RaycastHit hit;
            //         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), hit, 1000) && (!(hit.rigidbody == null))) {

            if (Physics.Raycast(ray, out hit, 1000) && (!(hit.rigidbody == null)))
            {
                //             var at = "";

                //string at = "";
                //             for (var h = 0; h < 8; h++)
                for (var h = 0; h < 8; h++)
                    //                 for (var v = 8; v > 0; v--) {
                    for (var v = 8; v > 0; v--)
                    {
                        //                     var id = "plane_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();		// Is this square mouse is over?
                        string id = "plane_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();

                        //                     var qObj = GameObject.Find(id);
                        var qObj = GameObject.Find(id);
                        //                     if ((!(qObj == null)) && (qObj.transform.position == hit.rigidbody.position)) at = id.Substring(6, 2);
                        if ((!(qObj == null)) && (qObj.transform.position == hit.rigidbody.position))
                        {
                            at = id.Substring(6, 2);

                        }
                        /// 
                        //                 }
                    }
                //             if (at.Length > 0) {
                if (at.Length > 0)
                {
                    //                 if (C0.c0_side < 0) at = Revert_at(at);
                    //function MouseMovement()
                    // Debug.Log("function MouseMovement_c0_side= " + C0.c0_side);
                    if (C0.c0_side < 0) at = Revert_at(at);
                    //             }
                }
                //         }
            }

            //     }
        }
        // }
        //close mousemovment
    }

    // function DragDetect(): void {
    void DragDetect()
    {

        GameObject q2Obj;
        GameObject q3Obj;
        GameObject q40bj;

        string Piece2promote;
        //     // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0)) return;
        //     // We need to actually hit an object
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000) && (!(hit.rigidbody == null)))
        {
            //         if (!C0.c0_moving) {	// If no piece is moving right now... (this animation algorithm is not good for the blitz-playing)
            if (!C0.c0_moving)
            {
                //             if (C0.c0_waitmove) {	// If waiting for action only...
                if (C0.c0_waitmove)
                {
                   


                    for (var h = 0; h < 8; h++)
                        for (var v = 8; v > 0; v--)
                        {
                            var id = "plane_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();
                            //Debug.Log("id=" + id);
                            var qObj = GameObject.Find(id);

                            if ((!(qObj == null)) && (qObj.transform.position == hit.rigidbody.position)) 
                            {
                               var qtobj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(at) : at));
                                if (!(qtobj == null)) qtobj.GetComponent<Renderer>().enabled = false;
                                Debug.Log("at="+at);
                                at = id.Substring(6, 2);
                               

                            } 
                            //                     }
                            //Debug.Log("at=" + at); mouse click place coordinate
                        }

                    //                 if (at.Length > 0) {

                    if (at.Length > 0)
                    {

                        //                     if (C0.c0_side < 0) at = Revert_at(at);
                        if (C0.c0_side < 0) at = Revert_at(at);
                        //                     if (drag1_at.Length > 0) {
                        if (drag1_at.Length > 0)
                        {

                            //                         q2Obj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                            
                            q2Obj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                            //                         if (!(q2Obj == null)) q2Obj.GetComponent.< Renderer > ().enabled=false;

                            Debug.Log("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                            
                            if (!(q2Obj == null)) q2Obj.GetComponent<Renderer>().enabled = false;
                            //                     }
                        }

                        //                     var piecedrag = C0.c0_D_what_at(at);
                        var piecedrag = C0.c0_D_what_at(at);
                        //                     if (mode == 2) {

                        //Debug.Log("piecedrag=" + piecedrag);
                        if (mode == 2)
                        

                        {
                            if ((piecedrag.Length > 0 && piecedrag.Substring(0, 1) == ((C0.c0_side > 0) ? white : black)))
                            {   // <- player vs player: white:black




                              
                                if (drag1_animator == 0)
                                {
                                    drag1_at = at;

                                    q3Obj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                                    if (!(q3Obj == null)) q3Obj.GetComponent<Renderer>().enabled = true;

                                }
                            }
                            else
                            {
//                             Piece2promote = "Q";
                                Piece2promote = "Q";
                                //                             if (toPromote == 1) Piece2promote = "R";
                                if (toPromote == 1) Piece2promote = "R";
                                else if (toPromote == 2) Piece2promote = "B";
                                //                             else if (toPromote == 3) Piece2promote = "N";
                                else if (toPromote == 3) Piece2promote = "N";

                                //                             C0.c0_become_from_engine = Piece2promote;
                                C0.c0_become_from_engine = Piece2promote;
                                //                             if ((drag1_at.Length > 0) && C0.c0_D_can_be_moved(drag1_at, at)) {

                                if ((drag1_at.Length > 0) && C0.c0_D_can_be_moved(drag1_at, at))
                                {
                                   

                                    
                                    //q40bj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(at) : at));
                                    //if (!(q3Obj == null)) q3Obj.GetComponent.< Renderer > ().enabled=true;
                                    //White squares appear underneath the chess piece
                                    //if (!(q40bj == null)) q40bj.GetComponent<Renderer>().enabled = true;
                                    C0.c0_move_to(drag1_at, at);
                                  
                                    C0.c0_sidemoves = -C0.c0_sidemoves;
                                    // C0.c0_side = -C0.c0_side;
                                    temp = white;
                                    white = black;
                                    black = temp;

                                    hide = true;
                                    alert = false;
                                    if (C0.c0_sidemoves == 1)
                                    {
                                        setCamSide = true;
                                        setCamSide2 = false;
                                    }
                                    else
                                    {
                                        setCamSide = false;
                                        setCamSide2 = true;
                                    }
                                }
                          
                            }
                            //                     }
                        }
                        //                     else if (mode == 1) {
                        else if (mode == 1)
                        {
                            //                         if ((piecedrag.Length > 0 && piecedrag.Substring(0, 1) == ((C0.c0_side > 0) ? "w" : "b"))) {
                            if ((piecedrag.Length > 0 && piecedrag.Substring(0, 1) == ((C0.c0_side > 0) ? "w" : "b")))
                            {
                                //                             if (drag1_animator == 0) {		// If the previous animation is over...
                                if (drag1_animator == 0)
                                {
                                    //                                 drag1_at = at;
                                    drag1_at = at;
                                    //                                 q3Obj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                                    q3Obj = GameObject.Find("plane_" + ((C0.c0_side < 0) ? Revert_at(drag1_at) : drag1_at));
                                    //                                 if (!(q3Obj == null)) q3Obj.GetComponent.< Renderer > ().enabled=true;
                                    //White squares appear underneath the chess piece
                                    if (!(q3Obj == null)) q3Obj.GetComponent<Renderer>().enabled = true;
                                    //DisplayPlane();
                                }
                            }
                            else
                            {
                                Piece2promote = "Q";
                                if (toPromote == 1) Piece2promote = "R";
                                else if (toPromote == 2) Piece2promote = "B";
                                else if (toPromote == 3) Piece2promote = "N";

                                C0.c0_become_from_engine = Piece2promote;
                                if ((drag1_at.Length > 0) && C0.c0_D_can_be_moved(drag1_at, at))
                                {
                                    C0.c0_move_to(drag1_at, at);
                                    C0.c0_sidemoves = -C0.c0_sidemoves;
                                    hide = true;

                                    alert = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // function PlanesOnBoard(): void {
    void PlanesOnBoard()
    {
        GameObject toObj;
        var a8Obj = GameObject.Find("plane_a8");
        var h1Obj = GameObject.Find("plane_h1");
        var dx = (h1Obj.transform.position.x - a8Obj.transform.position.x) / 7;
        var dy = (h1Obj.transform.position.y - a8Obj.transform.position.y) / 7;
        var dz = (h1Obj.transform.position.z - a8Obj.transform.position.z) / 7;

        //     for (var h = 0; h < 8; h++)
        for (var h = 0; h < 8; h++)
            for (var v = 8; v > 0; v--)
            {
                var id = "plane_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();
                if ((!(id == "plane_a8")) && (!(id == "plane_h1")))
                {
                    toObj = Instantiate(a8Obj, a8Obj.transform.position + new Vector3(dx * h, dy * (Mathf.Sqrt(Mathf.Pow(h, 2) + Mathf.Pow((8 - v), 2))), dz * (8 - v)), a8Obj.transform.rotation);//                 toObj.name = id;
                    toObj.name = id;
                    //             }
                }
                //         }
            }
        // }
        //   Debug.Log("PlanesOnBoard End");
    }

    // function TransformVisualAllToH1(): void {
    void TransformVisualAllToH1()
    {
        //     //Initial position:  Qd1, Ke1, Bf1, Ng1, Rh1, ph2, oponent'sNg3...
        //     // Coord-s should be adjusted according to piece type... the problem is that can't move piece to one x,y,z - looks different 

        TransformVisualPieceToH1("bishop", "f1");
        TransformVisualPieceToH1("queen", "d1");
        TransformVisualPieceToH1("king", "e1");
        TransformVisualPieceToH1("knight", "g1");
        TransformVisualPieceToH1("oponents_knight", "g3");
        TransformVisualPieceToH1("pawn", "h2");

        TransformVisualPieceToH1("DragParticle", "e1");
        TransformVisualPieceToH1("MoveParticle", "c3");
        // }
    }

    // function TransformVisualPieceToH1(piecetype: String, piece_from: String): void {
    void TransformVisualPieceToH1(string piecetype, string piece_from)
    {

        //     // Blender complect of pieces is good way to create models and put to Unity3D, just copy to assets folder,
        var Obj = GameObject.Find(((piecetype.IndexOf("Particle") >= 0) ? piecetype : "chessboard_min2/" + piecetype));
        var a8Obj = GameObject.Find("black_rook_scaled_a8");
        var h1Obj = GameObject.Find("white_rook_scaled_h1");
        var dx = (h1Obj.transform.position.x - a8Obj.transform.position.x) / 7;
        var dy = (h1Obj.transform.position.y - a8Obj.transform.position.y) / 7;
        var dz = (h1Obj.transform.position.z - a8Obj.transform.position.z) / 7;
        var h = System.Convert.ToInt32(piece_from[0]) - System.Convert.ToInt32("a"[0]);
        var v = System.Convert.ToInt32(piece_from.ToString().Substring(1, 1));
        Obj.transform.position += new Vector3(dx * (7 - h), dy * (Mathf.Sqrt(Mathf.Pow((7 - h), 2) + Mathf.Pow((v - 1), 2))), dz * (v - 1));
    }

    void HideBlankPieces()
    {

        GameObject.Find("black_rook_scaled_a8").GetComponent<Renderer>().enabled = false;
        GameObject.Find("white_rook_scaled_h1").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/pawn").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/knight").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/oponents_knight").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/bishop").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/rook").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/queen").GetComponent<Renderer>().enabled = false;
        GameObject.Find("chessboard_min2/king").GetComponent<Renderer>().enabled = false;

    }


    void CreatePiece(string piece_color, string piecetype, string piece_at)
    {
        // function CreatePiece(piece_color: String, piecetype: String, piece_at: String): void {

        GameObject toObj;
        var fromObj = GameObject.Find("chessboard_min2/" + piecetype);
        var piece_position = PiecePosition(piecetype, piece_at);

        toObj = Instantiate(fromObj, piece_position, fromObj.transform.rotation);
        toObj.name = "piece_" + piece_at;
        toObj.GetComponent<Renderer>().material = (GameObject.Find(((piece_color == "b") ? "black_rook_scaled_a8" : "white_rook_scaled_h1"))).GetComponent<Renderer>().material;

        toObj.GetComponent<Renderer>().enabled = true;
    }

    // function PiecePosition(piecetype: String, piece_at: String): Vector3 {
    Vector3 PiecePosition(string piecetype, string piece_at)
    {
        var a8Obj = GameObject.Find("black_rook_scaled_a8");
        var h1Obj = GameObject.Find("white_rook_scaled_h1");

        var dx = (h1Obj.transform.position.x - a8Obj.transform.position.x) / 7;
        var dy = (h1Obj.transform.position.y - a8Obj.transform.position.y) / 7;
        var dz = (h1Obj.transform.position.z - a8Obj.transform.position.z) / 7;

        var drx = -(h1Obj.transform.rotation.x - a8Obj.transform.rotation.x) / 7;
        var dry = -(h1Obj.transform.rotation.y - a8Obj.transform.rotation.y) / 7;
        var drz = -(h1Obj.transform.rotation.z - a8Obj.transform.rotation.z) / 7;

        var fromObj = GameObject.Find(((piecetype.IndexOf("Particle") >= 0) ? piecetype : "chessboard_min2/" + piecetype));
        var h = System.Convert.ToInt32(piece_at[0]) - System.Convert.ToInt32("a"[0]);
        var v = System.Convert.ToInt32(piece_at.Substring(1, 1));
        if (C0.c0_side < 0)
        {
            h = 7 - h;
            v = 9 - v;
        }

        //     // Very according to camera placement...
        //     //  The thing is that 2D board 8x8 calculation can't be measured with 3D vectors in a simple way. So, constants were used for existing models...
        var h1 = (7 - h) * 0.96;
        var v1 = (v - 1) * 1.04;

        return (fromObj.transform.position + new Vector3((float)-dx * (float)h1, (float)-dy * (float)0.6 * (Mathf.Sqrt(Mathf.Pow((float)h1, (float)2) + Mathf.Pow((float)v1, (float)2))), (float)-dz * (float)v1));

    }
    void position2board()
    {
        var c0_Zposition = C0.c0_position;
        for (var c0_i = 0; c0_Zposition.Length > c0_i; c0_i += 5)
        {
            var c0_Zcolor = c0_Zposition.Substring(c0_i, 1);
            var c0_Zfigure = c0_Zposition.Substring(c0_i + 1, 1);
            var c0_Z_at = c0_Zposition.Substring(c0_i + 2, 2);
            CreatePiece(c0_Zcolor, piecelongtype(c0_Zfigure, c0_Zcolor), c0_Z_at);
            //     }
        }
        // }
    }

    // function piecelongtype(figure1: String, color1: String): String {

    string piecelongtype(string figure1, string color1)
    {
        var ret = "";
        if (figure1 == "p") ret = "pawn";
        else if (figure1 == "N") ret = (((color1 == "w") && (C0.c0_side > 0)) || ((color1 == "b") && (C0.c0_side < 0)) ? "knight" : "oponents_knight");
        else if (figure1 == "B") ret = "bishop";
        else if (figure1 == "R") ret = "rook";
        else if (figure1 == "Q") ret = "queen";
        else if (figure1 == "K") ret = "king";
        return ret;
        // }
    }

    void DisplayPlane()
    {
        if (mode == 2) {


            for (var h = 0; h < 8; h++)
                for (var v = 8; v > 0; v--)
                {
                    var id = "plane_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();
                    //Debug.Log("id=" + id);
                    var qObj = GameObject.Find(id);
                    if (!(qObj == null)) qObj.GetComponent<Renderer>().enabled = false;
                   
                    //                     }
                    //Debug.Log("at=" + at); mouse click place coordinate
                }

        }
        else {
            var answer_plane_id = "plane_" + answer_plane;
            //                         var qObj = GameObject.Find(id);
            var qObjanswer = GameObject.Find(answer_plane_id);
            if (!(qObjanswer == null)) qObjanswer.GetComponent<Renderer>().enabled = false;

        }



    }

    // function DoPieceMovements(): void {
    void DoPieceMovements()
    {


        if (C0.c0_moves2do.Length > 0)
        {
            if (move_animator > 0)
            {
                var move_from = C0.c0_moves2do.Substring(0, 2);

                var move_to = C0.c0_moves2do.Substring(2, 2);

                var bc = (((C0.c0_moves2do.Length > 4) && (C0.c0_moves2do.Substring(4, 1) == "[")) ? C0.c0_moves2do.Substring(5, 1) : " ");

                GameObject mObj;
                mObj = GameObject.Find("piece_" + move_from);

                var pieceat = ((("QRBN").IndexOf(bc) >= 0) ? "p" : (C0.c0_D_what_at(move_to)).Substring(1, 1));
                var piececolor = (C0.c0_D_what_at(move_to)).Substring(0, 1);
                var piecetype = piecelongtype(pieceat, piececolor);

                var mfrom = PiecePosition(piecetype, move_from);
                var mto = PiecePosition(piecetype, move_to);
                //             // piece moves constantly towards the square...

                mObj.transform.position = mfrom + ((mto - mfrom) / 10 * (11 - move_animator));
                //             // a little jump for knight and castling rook...
                if ((piecetype.IndexOf("knight") >= 0) || ((bc == "0") && (piecetype == "rook")))
                    mObj.transform.position = new Vector3(mObj.transform.position.x, mObj.transform.position.y + (float)((move_animator - (5 - (move_animator > 5 ? 5 : move_animator)) + 3) * 0.2), mObj.transform.position.z);
                move_animator--;
                if ((!drawAnim) || (move_animator == 3))
                {

                    GameObject dObj;
                    dObj = GameObject.Find("piece_" + move_to);
                    if (dObj == null)
                    {
                        if ((piecetype == "pawn") && (!(move_from.Substring(0, 1) == move_to.Substring(0, 1)))) // en-passant...
                        {
                            dObj = GameObject.Find("piece_" + move_to.Substring(0, 1) + move_from.Substring(1, 1));
                            if (!(dObj == null)) Destroy(dObj);
                        }
                    }
                    else Destroy(dObj);
                }

                if (move_animator == 0)
                {
                    mObj.name = "piece_" + move_to;
                    if (("QRBN").IndexOf(bc) >= 0)
                    {
                        Destroy(mObj);
                        CreatePiece(piececolor, piecelongtype(bc, piececolor), move_to);
                    }
                    C0.c0_moves2do = (C0.c0_moves2do).Substring(((bc == " ") ? 4 : 7));

                    if (C0.c0_moves2do.Length == 0) C0.c0_moving = false;
                }

            }

            else
            {
                //             move_animator = (drawAnim ? GetTimeDelta(10, 4) : 1);					// 4 seconds animation anyway...
                move_animator = (drawAnim ? GetTimeDelta(10, 4) : 1);
                //drag1_animator = 0;
                drag1_animator = 0;
                //         }
            }
            //     }
        }
        // }
    }

    // // check gameover...
    IEnumerator checkGameover()
    {
        // message2show = "测试";

        if ((!gameover) && (engineStatus == 0) && (move_animator < 4))
        {
            if (C0.c0_D_is_check_to_king("w") || C0.c0_D_is_check_to_king("b"))
            {
                message2show = "将+";
                alert = true;
                if (C0.c0_D_is_mate_to_king("w"))
                {
                    alert = false; message2show = "将杀,黑方胜!"; gameover = true;
                    yield return new WaitForSeconds(5);
                }
                if (C0.c0_D_is_mate_to_king("b"))
                {
                    alert = false; message2show = "将杀,白方胜!"; gameover = true;
                    yield return new WaitForSeconds(5);

                }
            }
            else
            {
                if (((C0.c0_sidemoves > 0) && C0.c0_D_is_pate_to_king("w")) || ((C0.c0_sidemoves < 0) && C0.c0_D_is_pate_to_king("b"))) { message2show = "此局结束!"; gameover = true; }
            }
        }
        if (mode == 2)
        {
            //Debug.Log(menuArr[lang_flag, 22]);
            // Debug.Log("C0.c0_side"+C0.c0_side);
            if (C0.c0_sidemoves > 0) message2show = menuArr[lang_flag, 22];
            else message2show = menuArr[lang_flag, 21];
        }

        if (mode == 1)
        {
            if ((!gameover) && (C0.c0_moves2do.Length == 0) && (engineStatus == 0))
            {
                if (C0.c0_waitmove)
                {
                    if (mode == 1) message2show = menuArr[lang_flag, 13];
                }
                else if (!(C0.c0_sidemoves == C0.c0_side))
                {
                    message2show = menuArr[lang_flag, 14];
                    engineStatus = 1;
                }
            }
        }

    }

    // // this routine starts chess engine if needed...
    // function DoEngineMovements(): void {
    void DoEngineMovements()
    {
        C0.c0_waitmove = (C0.c0_sidemoves == C0.c0_side);
        StartCoroutine(checkGameover());
        if (engineStatus == 2)
        {
            (GameObject.Find("Script6")).SendMessage("JSSetDeep", chess_strength.ToString());
            (GameObject.Find("Script6")).SendMessage("JSRequest", C0.c0_get_FEN());
            engineStatus = 3;
        }
        // }
    }

    // // this call receives answer from the chess engine... (from other object)
    void EngineAnswer(string answer)
    {
        var move = "";
        GameObject q4Obj;

        if (answer.Length > 0)
        {
            if ((answer.Length > 9) && (answer.Substring(0, 10) == "Stockfish:"))
            {
                move = answer.Substring(11, 4);
                C0.c0_become_from_engine = ((answer.Length < 16) ? "Q" : (answer.Substring(15, 1)).ToUpper());
                if (move.Length > 0)
                {
                    message2show = answer.Substring(0, 13) + "-" + answer.Substring(13);
                    C0.c0_move_to(move.Substring(0, 2), move.Substring(2, 2));
                    C0.c0_sidemoves = -C0.c0_sidemoves;
                    hide = true;
                    alert = false;
                }
            }
            else
            {
                C0.c0_become_from_engine = ((answer.Length > 5) ? answer.Substring(6, 1) : "Q");
                if (C0.c0_D_can_be_moved(answer.Substring(0, 2), answer.Substring(3, 2)))
                {
                    message2show = "My move is " + answer;
                    answer_plane = answer.Substring(3, 2);
                    // Debug.Log("answer:"+answer.Substring(3,2));
                    C0.c0_move_to(answer.Substring(0, 2), answer.Substring(3, 2));
                    //add plane to answer planes
                    q4Obj = GameObject.Find("plane_" + answer.Substring(3, 2));
                    //                                 if (!(q3Obj == null)) q3Obj.GetComponent.< Renderer > ().enabled=true;
                    if (!(q4Obj == null)) q4Obj.GetComponent<Renderer>().enabled = true;
                    C0.c0_sidemoves = -C0.c0_sidemoves;
                    hide = true;
                    alert = false;
                }
            }
        }
        engineStatus = 0;
    }
    // // Takeback and new game starting is like RollBack - one/all moves.
    void RollBackAction()
    {
        if ((TakeBackFlag || NewGameFlag) && (!C0.c0_moving) && (C0.c0_moves2do.Length == 0))
        {
            if (gameover) gameover = false;

            for (var h = 0; h < 8; h++)
                for (var v = 8; v > 0; v--)
                {
                    var id = "piece_" + System.Convert.ToChar(System.Convert.ToInt32("a"[0]) + h) + v.ToString();		// Is this square mouse is over?
                    var qObj = GameObject.Find(id);
                    if (!(qObj == null)) Destroy(qObj);
                }
            if (TakeBackFlag)
            {
                if (mode == 1)
                {
                    C0.c0_take_back();
                    if (!(C0.c0_sidemoves == C0.c0_side)) C0.c0_take_back();
                    TakeBackFlag = false;
                }
                else if (mode == 2)
                {
                    if (C0.c0_moveslist == "")
                    {
                        TakeBackFlag = false;
                        setCamSide = true;
                    }
                    else
                    {
                        C0.c0_take_back();

                        if (white == "w") { setCamSide = true; setCamSide2 = false; }
                        if (white != "w") { setCamSide = false; setCamSide2 = true; }
                    }
                }
            }
            if (NewGameFlag)
            {
                if (mode == 1)
                {
                    C0.c0_set_start_position("");
                    C0.c0_sidemoves = 1;
                    C0.c0_waitmove = false;
                    C0.c0_side = -C0.c0_side;
                    C0.c0_waitmove = (C0.c0_side == C0.c0_sidemoves);
                    NewGameFlag = false;
                }
                else if (mode == 2)
                {
                    if (C0.c0_side == 1) { message2show = "轮到白方!"; }
                    else { message2show = "轮到黑方!"; }
                    C0.c0_set_start_position("");
                    C0.c0_sidemoves = 1;
                    C0.c0_waitmove = true;
                    setCamSide = true; setCamSide2 = false;
                    NewGameFlag = false;
                }
            }

            position2board();					// Set current position on the board visually...
        }
    }

    // function GetTimeDelta(min_interval: int, secs: int): int		// To slow animation on fastest CPU
    int GetTimeDelta(int min_interval, int secs)        // To slow animation on fastest CPU
    {
        var dt = ((Time.deltaTime * min_interval) / secs).ToString();		// 3-seconds to move...
        var pt = dt.IndexOf("."); if (pt < 0) pt = dt.IndexOf(".");
        var dt_int = System.Convert.ToInt32(((pt < 0) ? dt : dt.Substring(0, pt)));

        return Mathf.Max(min_interval, dt_int);
    }

    // function StockfishAccess(status: String): void {
    void StockfishAccess(string status)
    {
        StockfishAccessible = (status == "YES");
        if (!StockfishAccessible)
        {
            useStockfish = false;
            if (engineStatus > 0)
            {
                engineStatus = 0;			// actually pass to the next chess engine...
                message2show = "Stockfishcall error";
            }
        }
    }
    void OnApplicationQuit() { }
}