Image = imread('images3.png');
GT = graythresh(Image);
BW = im2bw(Image, GT);
figure
imshow(BW);