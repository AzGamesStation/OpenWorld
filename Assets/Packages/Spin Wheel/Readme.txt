1 ->Remove Following Errors According To You Porject.
1.1 --->Sound Manager Errors To Play Different Sounds As Per Requirement.
1.2 --->Change BG Music Script To Change Current Music Playing With Casino BG.
1.3 --->Preference Errors -> Replace It With Coin Get And Set Method Used In Your Project.
1.4 --->Global Constant, AdsManager And Firebase Errors With Methods Used In Your Project To Show And Rewards Ads.

2 ->Drag And Drop "SpinWheelConfigs" Prefeb In Scene.
3 ->Set Exit Function (On Exit Just SetActive(False) Spin Game Object In Child Not Parent And Other Changes According To Requirements).
4 ->Set Prizes Texts In Fortune Wheel Editor (Attached With Prefeb).
5 ->Open "FortuneWheel.cs" Script And Go to
5.1 --->ShowHideParticles() Function And Set Particles And Sounds For Prizes According To Texts Assigned Earlier In Editor.
5.2 --->ShowWinPanal() Function And Set Prizes Texts According To Texts Assigned Earlier In Editor.
5.3 --->GiveReward() Function And Set Prizes According To Texts Assigned Earlier In Editor.
5.4 --->GiveDoubleReward() Function And Set Double Prizes According To Texts Assigned Earlier In Editor.

---Possible Issues---
Issue: Arrow Striker Misplaced In Panal.
Solution: Find ArrowStricker GameObject (SpinWheelConfigs->Spin->SpinWheel) And Set Values Of "Hinge Joint 2D" Connected Anchors X, Y.
---------->Thank You<----------