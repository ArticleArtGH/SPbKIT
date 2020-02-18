mov @text,r0
M:
movb (r0),r1
cmp 60,r1
jg N
and df,r1
movb r1,(r0)+
cmp 0,(r0)
jnz M
N:
or 20,r1
movb r1, (r0)+
cmp 0,(r0)
jnz M

stop
text:
data "AbCeDf"
data 0

