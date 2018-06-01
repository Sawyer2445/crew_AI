# crew_AI
Crew_AI - коллектив решающих правил

Лабораторная работа по интеллектуальным системам. 
Цель работы - написать программу, реализующею коллектив решающих правил. 


## Принцип работы 
Программа состоит из трех перцептронов, обученных распознавать символы 'М', 'А', 'И'(папка с тремя весами  - weight).
Коллектив решает, относится ли нарисованный символ к символам перцептронов и говорит, что это за символ. 

## Решающее правило
Каждый перцептрон выдаёт 0 или 1. Формируется вектор-строка из этих значений. Вектор-строка умножается 
на вектор-столбец (1 2 3), тем самым получая число. 
````````
1 - 'М'
2 - 'А'
3 - 'И'
>3 - коллектив не знает, что это за символ.
`````````

