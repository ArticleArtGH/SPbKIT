mov ff,r0;mov c7,r0
push r0

;0-4
and 1f,r0                  
mov r0,r1
;mov r0,r1
;push r1

;5-6
pop r0
push r0
;mov r0,sp
and 60,r0
shr 5,r0;—двиг на 5 вдево
add r0,r1

;7
pop r0
;mov r0,sp
and 80,r0
shr 7,r0
add r0,r1
push r1

stop





