# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""

import numpy as np
from numpy import array
#zadanie 1
b= np.random.rand(5,10)*10
trace = np.trace(b)
diag = np.diag(b)
print('przekatna ',trace)
print('\n diag :\n',diag)



#zadanie 2

c=np.random.randn(1, 5) * 5
d=np.random.randn(1, 5) * 5
zadanie_2=c*d
print('\nzadanie 2 wynik : \n\n',zadanie_2)

#zadanie3


e= np.around(np.random.rand(5)*100)
f= np.around(np.random.rand(5)*100)
macierz_A = np.reshape(e,(1,5))
macierz_B = np.reshape(f,(1,5))
wynik_3=macierz_A+macierz_B

print("\n\n\nwynik zadanie - 3\n\n\n", wynik_3)

####zadanie 4 #################
print('\n\n\n zadanie 4 \n\n\n\n')
g=np.random.rand(4, 5) * 25
h=np.random.rand(5, 4) * 50
t=np.append([1,2,3,4,5],g)
h1=np.append([5,5,5,5,5],h)
wynik_4=t.reshape(5,5)+h1.reshape(5,5)
t1=t.reshape(5,5)
t2=h1.reshape(5,5)
print('\n wynik 4',wynik_4)

##zadanie - 5
print('\n\n\n zadanie.5\n\n')
mnozenie = t1[:,2]*t2[:,3]
print('\t\t\t wynik 5 \t \t \t' , mnozenie)

##zadanie - 6
print('\n\n\n zadanie.6\n\n')
x=np.random.randn(1, 5) * 5
y=np.random.randn(1, 5) * 5
x1=np.random.uniform(size=(1,5)) * 5
y1=np.random.uniform(size=(1,5)) * 5
variations1=np.var(x)
variations2=np.var(x1)
variations3=np.var(y)
variations4=np.var(y1)
deviations1=np.std(x)
deviations2=np.std(y)
deviations3=np.std(x1)
deviations4=np.std(y1)
average1=np.average(x)
average2=np.average(y)
average3=np.average(x1)
average4=np.average(y1)

variations_g=[variations1,variations3]
variations_u=[variations2,variations4]
devs_g=[deviations1,deviations2]
devs_u=[deviations3,deviations4]
avrgs_g=[average1,average2]
avrgs_u=[average3,average4]

print('odchylenia gaussa: ',variations_g,'odchylenie u',variations_u,'\nwariancje gasusa: ',variations_g,'wariencje u ',variations_u)
print('\n\n srednia dla gaussa : ',avrgs_g,'srednia u',avrgs_u)

#zadanie 7
print('\n\n\n zadanie.7\n\n')
g7=np.random.rand(2, 2) * 25
g8=np.random.rand(2, 2) * 50

print('macierze na poczatku: a ==  ',g7,'\n b===',g8)

print('a*b:   ',g7*g8)
print('z dot',np.dot(g7,g8))

##z funkcja dot sa wieksze wyniki 
##gdy mamy mnozenie macierzy 2-d jest warto wykorzystac dot

#####zadanie8
print('\n\n\n zadanie.8\n\n')
cc=np.random.rand(5,5)
print('macierz ', cc , '\n')
print(np.lib.stride_tricks.as_strided(cc,(3,1),cc.strides))

