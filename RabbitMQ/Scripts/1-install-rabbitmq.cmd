helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
helm repo update
helm install -f rabbitmq-values.yaml rabbitmq bitnami/rabbitmq
helm install -f nginx-values.yaml ingress-nginx ingress-nginx/ingress-nginx

set /p DUMMY=Hit ENTER to continue...