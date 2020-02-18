mov 03c0,r0
out r0,p0
out r0,p7

mov 07a0,r0
mov 0620,r1
out r0,p1
out r1,p6

mov 0e90,r0
out r0,p2
out r0,p5

mov 0f90,r0
mov 0e10,r1
out r0,p3
out r1,p4


push r0
xor r0,r0
system 02
pop r0
ret
   

mov 03c0,r0
out r0,p0
out r0,p7

mov 07a0,r0
mov 0620,r1
out r0,p6
out r1,p1

mov 0e90,r0
out r0,p5
out r0,p2

mov 0f90,r0
mov 0e10,r1
out r0,p4
out r1,p3

stop


