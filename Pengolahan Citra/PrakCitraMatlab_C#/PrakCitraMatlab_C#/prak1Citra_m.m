%=================================Baris kode untuk melakukan Load Image=========================
clf
gambar=imread('tebing.jpg');
size(gambar)
figure, image(gambar);
%I=gambar(200:300,170:300,:);
%figure, image(I);
%=================================Mulai Fungsi Modifikasi RGB===================================
red=gambar(:,:,1);
green=gambar(:,:,2);
blue=gambar(:,:,3);
%=================================Mendefinisikan warna RGB======================================
a = zeros(size(gambar, 1), size(gambar, 2));%inisialisasi matrix 0

%=================================Mendefinisikan matrix untuk masing masing percobaan===========
just_red = cat(3, red, a, a); %matrix untuk channel merah
just_green = cat(3, a, green, a); %matrix untuk channel hijau
just_blue = cat(3, a, a, blue); %matrix untuk channel biru
%-------Kode di atas baris ini untuk modifikasi channel--------dibawah, untuk filter grayscale--
just_grayr = cat(3, red, red, red);
just_grayg = cat(3, green, green, green);
just_grayb = cat(3, blue, blue, blue);
%===============================================================================================

%--------------Menampilkan image normal------------------
%back_to_original_img = cat(3, red, green, blue);
%figure, imshow(gambar), title('Original image')
%--------------------------------------------------------

%=================================Menampilkan masing masing percobaan==========================
figure, imshow(just_red), title('Red channel') %Untuk filter red channel
figure, imshow(just_green), title('Green channel') %untuk filter channel hijau
figure, imshow(just_blue), title('Blue channel') %untuk filter channel biru

figure, imshow(just_grayr), title('Gray channel red') %untuk filter grayscale merah
figure, imshow(just_grayg), title('Gray channel green') %untuk filter grayscale hijau
figure, imshow(just_grayb), title('Gray channel blue') %untuk filter grayscale biru

%figure, imshow(back_to_original_img), title('Back to original image') %Original image

%=================================Definisi matrix untuk sephia==================================
sephia=uint8(cat(3,((red*.393)+(green*0.769)+(blue*.189)),((red*.349)+(green*.686)+(blue*.168)),((red*.272)+(green*.534)+(blue*.131)))); %fungsi kode untuk sephia
%-----------------------tampilkan sephia-----------------------------
figure,imshow(sephia),title('Sephia'); %menampilkan sephia

%=================================Matrix untuk grayscale========================================
gray=(red+green+blue)/3;
figure,imshow(gray),title('Gray Scale');
figure,imshow(red);
figure,imshow(green);
figure,imshow(blue);
