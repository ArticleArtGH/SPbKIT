;–асчЄт,не идеальный
;в св€зи с округлением
mov 2710,r0 ;10000
;1-1%   ;mov 1,r1 ;1%
mov 15,r1 ;21
call procent
finish:
;ќтвет
push r0
stop

procent:
cmp 0,r1
jz finish
push r0
div 64,r0 ; /
mul 1,r0
push r1
mov r0,r1 ;прирост
;возвращаем значение
;во регитср r0, таким
;способом т.к. более
;одного раза помещал
;значение в стек
;как pop
mov sp,r0
add 2,r0
mov (r0),r0
;
add r1,r0
pop r1
sub 1,r1
call procent
ret

