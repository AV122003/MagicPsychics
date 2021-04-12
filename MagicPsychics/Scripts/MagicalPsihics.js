var ulyAudio = new Audio('Content/Audio/uly.mp3');    

function MakePuzzle(puzzleWait) {
    var puzzle = document.getElementById('User_Puzzle');
    var puzzleValue = 0;
    if (!!puzzle)
        puzzleValue = parseInt(puzzle.value, 10);

    if (!puzzleWait && (Math.abs(puzzleValue) < 10 || Math.abs(puzzleValue) > 99))
            $("#puzzleError").css("display", "block");
    else
        $.ajax({
            url: "/Home/PartialPuzzle",
            type: "POST",
            cache: false,
            data: { __RequestVerificationToken: GetToken(), puzzle: puzzleValue },
            success: function (data) {
                document.getElementById('Puzzle').innerHTML = data;
                if (!puzzleWait)
                    $.ajax({
                        url: "/Home/PartialPuzzleHistory",
                        type: "GET",
                        cache: false,
                        data: {},
                        success: function (data) {
                            document.getElementById('PuzzleHistory').innerHTML = data;

                            $.ajax({
                                url: "/Home/PartialPsyhic",
                                type: "GET",
                                cache: false,
                                data: {},
                                success: function (data) {
                                    document.getElementById('Psyhic').innerHTML = data;
                                    $.ajax({
                                        url: "/Home/GuessSuccessNumber",
                                        type: "GET",
                                        cache: false,
                                        data: {},
                                        success: function (data) {
                                            var i = parseInt(data, 10);
                                            if (i == 0)
                                                ulyAudio.play();
                                        },
                                        error: function (xhr, ajaxOptions, thrownError) {
                                            alert(xhr.status);
                                            alert(xhr.responseText);
                                            alert(thrownError);
                                        }
                                    })
                                },
                                error: function (xhr, ajaxOptions, thrownError) {
                                    alert(xhr.status);
                                    alert(xhr.responseText);
                                    alert(thrownError);
                                }
                            })
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert(xhr.status);
                            alert(xhr.responseText);
                            alert(thrownError);
                        }
                    })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
                alert(thrownError);
            }
        })
}
