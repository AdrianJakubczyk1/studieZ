# -*- coding: utf-8 -*-
"""
Created on Mon Mar 30 17:29:30 2020

@author: adrian
"""
import numpy as np;
from matplotlib import pyplot as plt;
import matplotlib.image as mpimg
import PIL
from PIL import Image
import imageio
import skimage.color
import skimage.filters
import skimage.io
import skimage.viewer

def dyskretyzacja(F,f):
     dt = 1/F;
     t= {};
     increment = 0;
     while increment < 1:
         
         s =   np.sin(2*np.pi*f*increment) ;
         t[increment]=s;
         increment+=dt;
     return t;

def makeChart(F, f):
    getValues = dyskretyzacja(F,f);
    k = list(getValues.keys())
    x = list(getValues.values());
    plt.plot(k,x, label='y = x')
    plt.title('wykres sinusa dla '+str(F)+'Hz')
    plt.ylabel('dt Axis')
    plt.legend(loc = 'best')

    plt.show()        
     
#makeChart(20,10)
#makeChart(21,10)
#makeChart(30,10)
#makeChart(45,10)
#makeChart(50,10)
#makeChart(100,10)
#makeChart(200,10)
#makeChart(250,10)
#makeChart(1000,10)

###############################
#4.prawo Shannona-Nyquista
#################################
#5.zjawisko to nazywa sie aliasing
###############################

#########
#zad.2

 
pic = mpimg.imread('./anaconda1.png')
def kwantyzacja_get_size():
    
    #image = Image.open('./anaconda1.png')
    #print("wymiary",image.size)
    
    print('Shape of the image : {}'.format(pic.shape))
    #data = asarray(image)
    print("pojedynczy pixel is opisywany:",pic[ 100, 50 ])
    print('Maximum RGB value in this image {}'.format(pic.max()))
    print('Minimum RGB value in this image {}'.format(pic.min()))
    
    



def gray1():
       
    grayImages = []
    grayImages.append(np.zeros(shape = (pic.shape[0], pic.shape[1])))
    grayImages.append(np.zeros(shape = (pic.shape[0], pic.shape[1])))
    
    for i, row in enumerate(pic):
        for j, pixel in enumerate(row):
            grayImages[0][i, j] = (max(pixel) + min(pixel)) / 2
            grayImages[1][i, j] = (pixel.mean())
            
    
            

            
   
    
def usrednienie():
    gray = lambda rgb : np.dot(rgb[... , :3] ,0.333) 
    gray = gray(pic)  

    plt.figure( figsize = (10,10))
    plt.imshow(gray, cmap = plt.get_cmap(name = 'gray'))
    plt.show()
    return gray

      
    
def luminancja():
    gray = lambda rgb : np.dot(rgb[... , :3] ,[0.299 , 0.587, 0.114]) 
    gray = gray(pic)  

    plt.figure( figsize = (10,10))
    plt.imshow(gray, cmap = plt.get_cmap(name = 'gray'))
    plt.show()
    return gray

#luminancja()
#usrednienie()
#gray1()

def histogram():
    
    pic = luminancja();
    
    plt.hist(pic.ravel(),bins = 32); 
   
     
#histogram()



def reduction_histogram():
    
    pic = luminancja();
    pic2 = usrednienie();
    
    
    plt.hist(pic2.ravel(),bins = 16); 
    plt.hist(pic.ravel(),bins = 16); 
    
    
#reduction_histogram()

def part7():
    _,bins=np.histogram(pic)
    pic1 = np.digitize(pic, bins) 
    nowyObraz = np.histogram(pic1-1)

    plt.hist(nowyObraz)
    
    
def part8():
    reduction_histogram()
    
#part8()
    
    
    
######################
 ##   binaryzacja ###
###################3
    
pic2 = imageio.imread('./gradient.jpg')
    
def grayness():
    gray = lambda rgb : np.dot(rgb[... , :3] ,[0.299 , 0.587, 0.114]) 
    gray = gray(pic2)  

    plt.figure( figsize = (10,10))
    #plt.imshow(gray, cmap = plt.get_cmap(name = 'gray'))
    #plt.show()
    h = plt.hist(pic2.ravel(),bins = 16); 
    
    return gray


def progowanie():
    x=grayness()
    t = skimage.filters.threshold_otsu(pic2)
    im_bool = x>t
    plt.imshow(im_bool)
    plt.show()
    
progowanie()
  

     





