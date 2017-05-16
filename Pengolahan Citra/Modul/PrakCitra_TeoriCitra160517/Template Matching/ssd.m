function z=ssd(h,x);
nh=size(h);
n=size(x);

k=floor(nh(1)/2);
y=zeros(n(1)+2*k,n(2)+2*k);
y(k+1:n(1)+k,k+1:n(2)+k)=x;
yd=y;

for i=k+1:n(1)+k
    for j=k+1:n(2)+k
        u=0;
        for k1=1:nh(1)
            for k2=1:nh(2)
                u=u+(h(k1,k2)-y(i+k1-k-1,j+k2-k-1))^2;
            end
        end
        yd(i,j)=sqrt(u);
    end
end

z=yd(k+1:n(1)+k,k+1:n(2)+k);