$uri = "http://localhost:57756/api/departments/5"

$headers = @{
    'Content-Type'='application/json'
    'Authorization' = 'TokenValue'
}

curl -Uri $uri -Method Delete -Headers $headers 
