# -*- coding: utf-8 -*-
"""
Created on Mon Mar 16 18:37:56 2020

@author: adrian
"""

import numpy as np
import pandas as pd
import scipy.stats as sci
import matplotlib.pyplot as plt
from scipy.optimize import curve_fit 
df = pd.DataFrame({"x": [1, 2, 3, 4, 5], 'y': ['a','b','a','b','b']})
#
def zad1():
   
    result_1 = df.groupby('x').apply(lambda x:np.mean(x))  
    print(result_1.head(),' \n \n zadanie 1 \n \n \n')
    

def zad2():
    result = pd.value_counts(df.values.flatten())
    print(result)
    


def zad3():
    fname = 'autos.csv'
    x = np.loadtxt(fname,dtype=str)
    result = pd.read_csv(fname)
    print(result,"\n \n read csv \n \n",x,"\n loadtxt")
    #read csv prezentuje dane w zdecydowanie czytelniejszy sposob.

def zad4():
    
    
    result2 = data.groupby('make').apply(lambda x:np.mean(x))
    print(result2)

    


def zad5():
    
    result2 = data.groupby('make').apply(lambda x:pd.value_counts(x['fuel-type']))
    print(result2)
    

def zad6():
    
    ps3 = np.array(data['city-mpg'])
    ps4=np.array(data['length'])
  
    D = np.polyfit(ps3,ps4,1)
    p = np.polyfit(ps3,ps4,2)
    print(D,p)
  


def zad7():
    first = data.corr(method ='pearson') 
   # second = data.corr(method ='pearson').apply(lambda x: np.polyfit) 
    #print(first[])
 


def zad8():
    first = data.corr(method ='pearson') 
    ps3 = np.array(data['city-mpg'])
    ps4=np.array(data['length'])
  
    D = np.polyfit(ps3,ps4,1)
   
    plt.plot(D,'--')
    plt.show()
    plt.plot(first,'k',markersize=2)
    plt.show
   




def zad9():
    #x = np.vstack(data['length'])
    x = data['length'][np.logical_not(np.isnan(data['length']))]
    kernel = sci.gaussian_kde(x)
    change = np.array(kernel)
    xmin = data['length'].min()
    xmax = data['length'].max()
    X = np.mgrid[xmin:xmax:100j]
    positions = np.vstack([X.ravel()])
    Z = np.reshape(kernel(positions).T, X.shape)
    fig = plt.figure()
    ax = fig.add_subplot(111)
    
    ax.plot(x, 'k.', markersize=2)
    ax.set_xlim([xmin, xmax])
    density = np.histogram(data['length'], density=True)
    xD = np.delete(density[1],10)
    print(np.shape(xD))
    plt.show()
    #density = np.histogram(kernel, density=True)
    
    #plt.plot(x,'bs',density[1],'--','black')
    #plt.show()
zad1()