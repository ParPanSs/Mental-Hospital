EXTERNAL language(currentLang)
EXTERNAL finishDay(dayIndex)

~ temp currentLanguage = language("")

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
Это психотерапевт. Диалог с ним, к сожалению, все еще отсутсвует.
~ finishDay(2)
-> END

= EN
This is psychoterapeut. Dialogue with him is absent, regretfully.
~ finishDay(2)
->END

= CS
To je psychoterapeut. Dialog s nim chybi. Je mi lito.
~ finishDay(2)
-> END