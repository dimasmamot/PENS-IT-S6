img = imread('bunga_warna.jpg');
img_hsv = rgb2hsv(img);
subplot(1,2,1), imshow(img), title('Gambar RGB');
subplot(1,2,2), imshow(img_hsv), title('Gambar HSV');
