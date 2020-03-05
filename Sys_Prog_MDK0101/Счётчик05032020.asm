push r0 ;для сохранения
;данных предыдущих
mov 5,r0
push r0
system 0
call schet
finish:
system 12
pop r0
stop


schet:
cmp 0,r0
jz finish
system 12
sub 1,r0
call schet
ret

