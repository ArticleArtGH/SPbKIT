mov 96,r0 ;150
div 3,r0
mov 4e,r1 ;78
div 2,r1 ;r1
add r1,r0
mov 16d,r1 ;365
div 5,r1
add r1,r0
mov 70,r1
mov r0,(r1)
              
;mov @memory,r0
;mov m,(r0)

stop
memory:
data bb


