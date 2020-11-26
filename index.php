<?php
 
$method = $_SERVER['REQUEST_METHOD'];
 
 
if($method == 'POST'){
	$requestBody = file_get_contents('php://input');
	$json = json_decode($requestBody);
 
	$text = $json->queryResult->queryText;   // ACCEDO POR queryText para que sea más sencillo, e igualmente no anda. En realidad debería ser queryResult->parameters->text;
 
	switch ($text) {
		case 'hola':
			$speech = "Hola";
			break;
 
		case 'chau':
			$speech = "Chau";
			break;
 
		case 'Cualquiera':
			$speech = "Cualquiera.";
			break;
 
		default:
			$speech = "Perdon, no entendí lo que dijiste";
			break;
	}
	$response = $json;
	$responde->queryResult;
	$response->fulfillmentText = $speech;
	$response->fulfillmentMessages = array(
		array(
			"text" => array(
			"text" => array($speech)
 
			)
		)
	);
	$myjson= json_encode($response);
	echo $myjson;
}
else
{
	echo "Metodo no encontrado";
}
 
?>