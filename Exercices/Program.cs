using Exercices.Operations;
using Exercices.Transformation;

var transformer = new GuidAndUrlOptimizedTransformer();
var urlToGuid = new Ex01FriendlyUrlToGuid(transformer);
urlToGuid.Run();

var guidToUrl = new Ex01GuidToFriendlyUrl(transformer);
guidToUrl.Run();
