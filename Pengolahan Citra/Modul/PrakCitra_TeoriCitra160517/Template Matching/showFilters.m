clear
clc
a=makeLMfilters;

for n=1:48
    b=a(:,:,n);
    bmin=min(min(b));
    bmax=max(max(b));
    c=255*(b-bmin)/(bmax-bmin);
    d=uint8(c);
    subplot(4,12,n), imshow(d)
end
