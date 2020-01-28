$uri = "http://localhost:57756/api/departments"
$body = '
{
 "name":"New Department"
}
'
$headers = @{
    'Content-Type'='application/json'
    'Authorization' = 'TokenValue'
}
curl -Uri $uri -Method Post -Headers $headers -Body $body 
