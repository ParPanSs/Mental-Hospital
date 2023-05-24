INCLUDE globals.ink

{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

=RU
Это психотерапевт. Диалог с ним, к сожалению, все еще отсутсвует. #portrait:Psychoterapeut
    *[Закончить день]
        ~ finishDay()
        -> DONE
    *[Уйти]
        -> DONE
-> END

=EN
This is psychoterapeut. Dialogue with him is absent, regretfully. #portrait:Psychoterapeut
    *[Finish the day]
        ~ finishDay()
        -> DONE
    *[Leave]
        -> DONE
->END

=CS
To je psychoterapeut. Dialog s nim chybí. Je mi lito. #portrait:Psychoterapeut
    *[Ukončit den]
        ~ finishDay()
        -> END
    *[Ujít]
        -> DONE
-> END