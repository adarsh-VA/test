$("#dash").click(()=>{
    console.log("clicked");
    $("#navlist").toggle("0.3s","linear");
    $("#dash").css("display","none");
    $("#drop-close").css("display","inline-block");
});

$("#drop-close").click(()=>{
    console.log("clicked");
    $("#navlist").toggle("0.3s","linear");
    $("#dash").css("display","block");;
    $("#drop-close").css("display","none");
});