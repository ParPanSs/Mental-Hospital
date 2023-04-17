EXTERNAL language(currentLang)

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
Здесь должна быть финальная версия диалога между Матерью и Кайлом, однако, он все еще в процессе написания.

Уважаемый Станислав Викторович, мы сломали Четвертую Стену специально, чтобы вы знали, как упорно и ответственно мы подходим к работе.

    *[Заплакать]
        О нет, не плачьте! На следующем Майлстоуне будет много изменений!
        ->DONE
    *[Отмена]
        ...
        -> DONE
-> END
= EN
There's should be final version of dialogue between Mother and Kyle, but it's still in the process of writing.

Dear Stanislav Viktorovich, we broke The Fourth Wall just for you information, how carefully and hard we are working.
    
    * [Cry]
        Oh no, don't cry! The next Milestone will bring you a lot of changes!
        ->DONE
    * [Cancel]
        ...
        -> DONE
-> END
= CS
Zde by měla být finální verze dialogu mezi matkou a Kylem, ten je však stále v procesu psaní.

Vážený Stanislave Viktoroviče, prolomili jsme čtvrtou zeď, abyste věděl, jak tvrdě a zodpovědně přistupujeme k práci.

    * [Plakat]
        Ale ne, neplačte! Příští Milestone přinese mnoho změn!
        -> DONE
    *[Zrušení]
        ...
        -> DONE
->END