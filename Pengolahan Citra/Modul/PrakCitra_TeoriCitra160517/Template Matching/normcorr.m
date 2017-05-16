function z=normcorr(h,x);
nh=size(h);
n=size(x);

k=floor(nh(1)/2);
y=zeros(n(1)+2*k,n(2)+2*k);
y(k+1:n(1)+k,k+1:n(2)+k)=x;
yd=y;

hm=mean(mean(h));
xm=mean(mean(x));
for i=k+1:n(1)+k
    for j=k+1:n(2)+k
        u=0;
        u1=0;
        u2=0;
        for k1=1:nh(1)
            for k2=1:nh(2)
                u=u+(h(k1,k2)-hm)*(y(i+k1-k-1,j+k2-k-1)-xm);
                u1=u1+(h(k1,k2)-hm)^2;
                u2=u2+(y(i+k1-k-1,j+k2-k-1)-xm)^2;
            end
        end
        yd(i,j)=u/sqrt(u1*u2);
    end
end

z=yd(k+1:n(1)+k,k+1:n(2)+k);