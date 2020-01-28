$uri = "http://localhost:57756/api/departments/"

$body = '
{
 "id":5,
 "name":"Updated Department"
}
'

$headers = @{
    'Content-Type'='application/json'
    'Authorization' = 'TokenValue'
}

curl -Uri $uri -Method Put -Headers $headers -Body $body 
