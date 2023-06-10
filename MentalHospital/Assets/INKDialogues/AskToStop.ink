INCLUDE globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
~firstCharacteristic = checkCharacteristic(0)
{ 
    - firstCharacteristic == "Introvert": 
        Черт, надеюсь кто-то скажет за меня...
    - firstCharacteristic == "Extravert":
        На остановке, пожалуйста!
}
-> END

= EN
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END

= CS
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END