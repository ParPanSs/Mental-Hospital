INCLUDE globals.ink
//EXTERNAL language(currentLang)


{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

=RU
Это психотерапевт. Диалог с ним, к сожалению, все еще отсутсвует.
    *[Закончить день]
//        ~ finishDay()
        -> DONE
    *[Уйти]
        ...
-> END

=EN
This is psychoterapeut. Dialogue with him is absent, regretfully.
    *[Finish the day]
//        ~finishDay()
        -> DONE
    *[Leave]
        ...
->END

=CS
To je psychoterapeut. Dialog s nim chybi. Je mi lito.
    *[Ukoncit den]
//        ~finishDay()
        -> DONE
    *[Ujit]
        ...
-> END