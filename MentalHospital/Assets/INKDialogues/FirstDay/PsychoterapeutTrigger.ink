INCLUDE ../globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
Здравствуй, Ян, как будешь готов, сядь на диван, и мы сможем начать консультацию. #portrait:Psychoterapeut
~offCollider()
-> END

== EN
The bowl is full.
-> END

== CS
Mísa je plná.
-> END