docker build -f "C:\Users\abel.vallejo\source\repos\dockertraining_Abel_Vallejo\dockertraining_Abel_Vallejo\Dockerfile" --force-rm -t dockertrainingabelvallejo  "C:\Users\abel.vallejo\source\repos\dockertraining_Abel_Vallejo" 

docker run --name Site1 -p 8085:80 d1aea1254d52

docker run --name Site2 -p 8086:80 -e "AppSettings:StoreName"="Plano" d1aea1254d52
