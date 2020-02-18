;mov 1,r3
mov @x,r0
c:
mov (r0)+,r1
mov r1,r2
and 1,r2
cmp 1,r2;r2=r2-1 если 1 то умножение
jz NCH
div 2,r1 
jmp finish
NCH:
mul 2,r1
finish:
mov r1,y
;add 1,r3
cmp 0,r2
jnz c

stop
x:
data 19
data 18
data 3
data 0
y:
data dd
data 0
data 0

