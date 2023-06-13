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
~firstCharacteristic = checkCharacteristic(0)
{ 
    - workWasDone == true && firstCharacteristic == "Introvert": 
        О чем думают люди, когда ждут что-то? О погоде? Сегодня облачно... #portrait:default
        ~ callBus()
    - workWasDone == true && firstCharacteristic == "Extravert":
        Сегодня облачно, правда? #portrait:default
        ... #portrait: Granny
        ~ callBus()
    - workWasDone == false:
        Если я уеду, даже не появившись на рабочем месте, я рискую потерять работу.
}
-> END

= EN
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END

= CS
{ - workWasDone == true: Надеюсь, автобус приедет быстро. | Рабочий день не закончен, я не могу уехать. }
-> END