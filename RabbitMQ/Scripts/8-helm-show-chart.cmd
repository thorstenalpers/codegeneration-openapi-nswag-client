REM Test that chart works as expected
helm show values ../Consumer/charts/consumer > tmp-consumer-values.yaml
helm template ../Consumer/charts/consumer > tmp-consumer-template.yaml

helm show values ../Consumer/charts/producer > tmp-producer-values.yaml
helm template ../Consumer/charts/producer > tmp-producer-template.yaml
