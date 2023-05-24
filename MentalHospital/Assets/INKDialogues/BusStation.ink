INCLUDE globals.ink
EXTERNAL callBus()

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
{ 
    - workWasDone == true: 
        Надеюсь, автобус приедет быстро. 
        ~ callBus()  
    - workWasDone == false:
        Рабочий день не закончен, я не могу уехать. 
}
-> END

= EN
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END

= CS
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END