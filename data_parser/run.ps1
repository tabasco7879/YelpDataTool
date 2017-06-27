$cp="..\stanford-corenlp-full-2015-04-20\ejml-0.23.jar"
$cp=$cp + ";..\stanford-corenlp-full-2015-04-20\joda-time.jar"
$cp=$cp + ";..\stanford-corenlp-full-2015-04-20\jollyday.jar"
$cp=$cp + ";..\stanford-corenlp-full-2015-04-20\stanford-corenlp-3.5.2.jar"
$cp=$cp + ";..\stanford-corenlp-full-2015-04-20\stanford-corenlp-3.5.2-models.jar"
$cp=$cp + ";..\stanford-corenlp-full-2015-04-20\xom.jar"
$cp=$cp + ";..\sqljdbc_6.0\enu\sqljdbc4.jar"
$cp=$cp + ";.\bin\"

$auth_path="..\sqljdbc_6.0\enu\auth\x64"

java -cp $cp -Xmx4g -D"java.library.path"=$auth_path data_parser.Document

