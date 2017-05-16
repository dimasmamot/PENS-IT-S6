img = imread('bunga_warna.jpg');
img_hsv = rgb2hsv(img);
hue = img_hsv(:,:,1);
saturation = img_hsv(:,:,2);
value = img_hsv(:,:,3);
subplot(2,2,1), imshow(img_hsv), title('Gambar HSV');
subplot(2,2,2), imshow(hue), title('Hue');
subplot(2,2,3), imshow(saturation), title('Saturation');
subplot(2,2,4), imshow(value), title('Value');