az login

CREATING AKS ENVIRONMENT

az provider register -n Microsoft.ContainerService

az group create --name rgTestKubernetes --location westeurope

az aks create --resource-group rgTestKubernetes --name AKSCluster --node-count 2 --generate-ssh-keys --enable-managed-identity

az aks get-credentials --resource-group rgTestKubernetes --name AKSCluster --overwrite-existing

kubectl create namespace tech-meetup

kubectl delete deployment --ignore-not-found apicountk8s -n tech-meetup

kubectl delete service apicountk8s

kubectl create -f .\apicount-deployment.yml -n tech-meetup

kubectl create -f .\apicount-service.yml -n tech-meetup

kubectl scale deployment apicountk8s --replicas=10 -n tech-meetup

kubectl get deployments -n tech-meetup

kubectl get pods -n tech-meetup

kubectl delete namespace tech-meetup

kubectl get pods -n tech-meetup

kubectl get deployments -n tech-meetup

kubectl get services -n tech-meetup

az group delete --name rgTestKubernetes --yes --no-wait

az group delete --name NetworkWatcherRG --yes --no-wait

az group delete --name MC_rgTestKubernetes_AKSCluster_westeurope --yes --no-wait