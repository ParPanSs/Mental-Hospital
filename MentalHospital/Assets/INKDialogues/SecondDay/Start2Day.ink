INCLUDE ../globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
Я снова здесь. Не помню, что делал всю прошлую неделю.
-> END

= EN
{ dogWasKicked == false: This is a dog. It's still seems to be happy. | You've kicked the dog yesterday, so it's in fear of you. }
-> END

= CS
{ dogWasKicked == false: Tohle je pes. Ještě vypádá šťastné. | Vy jste kopnuli psa včera, tak teď se vás bojí. }
-> END