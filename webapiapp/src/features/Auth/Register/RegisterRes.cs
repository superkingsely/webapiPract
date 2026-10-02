


// public class ApiResponse<T>
// {
//     public string Message { get; set; }="";
//     public bool IsSuccessful { get; set; }

//     public T? data{get;set;}

//     public static ApiResponse<T> Successful(T data)
//     {
//         var apires= new ApiResponse<T>
//         {
//             Message="job well done boss!!!",
//             IsSuccessful=true,
//             data=data
//         };
//         return apires;
//     }
//     public static ApiResponse<T> failed(string message)
//     {
//         var apires= new ApiResponse<T>
//         {
//             Message=message,
//             IsSuccessful=false
            
//         };
//         return apires;
//     }
// }