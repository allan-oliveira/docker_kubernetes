https://labs.play-with-docker.com/

docker pull hello-world
docker pull docker/getting-started

docker run -d -p 80:80 docker/getting-started

docker login

docker build . --tag allanrj/apicountk8s:1.0

docker run --name apicountk8s-01 -p 1234:80 allanrj/apicountk8s:latest -d

docker tag allanrj/apicountk8s:1.0 allanrj/apicountk8s:latest (best practice)

docker push allanrj/apicountk8s

docker pull allanrj/apicountk8s