using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Quantity", "SellerId", "Title" },
                values: new object[,]
                {
                    { 1, "Lê Bảo Ngọc", 1, "SÓI VÀ CỪU - BẠN KHÔNG TỐT NHƯ BẠN NGHĨ ĐÂU!\r\n\r\nLàn ranh của việc ngây thơ hay xấu xa đôi khi mỏng manh hơn bạn nghĩ.\r\n\r\nBạn làm một việc mà mình cho là đúng, kết quả lại bị mọi người khiển trách.\r\n\r\nBạn ủng hộ một quan điểm của ai đó, và số đông khác lại ủng hộ một quan điểm trái chiều.\r\n\r\nRốt cuộc thì bạn sai hay họ sai?\r\n\r\nCuốn sách “Không phải sói nhưng cũng đừng là cừu” đến từ tác giả Lê Bảo Ngọc sẽ giúp bạn hiểu rõ hơn những khía cạnh sắc sảo phía sau những nhận định đúng, sai đơn thuần của mỗi người.\r\n\r\nNhững câu hỏi đầy tính tranh cãi như “Cứu người hay cứu chó?”, “Một kẻ thô lỗ trong lớp vỏ “thẳng tính” khác với người EQ thấp như thế nào?”, “Vì sao một bộ phận nữ giới lại victim blaming đối với nạn nhân bị xâm hại?”, được tác giả đưa ra trong “Không phải sói nhưng cũng đừng là cừu”. Bằng từng chương sách của mình, tác giả vạch rõ cho bạn rằng “thật sự thế nào mới là người tốt”, ngây thơ và xấu xa có ranh giới rõ ràng như thế không, rốt cuộc bạn có là người tốt như mình vẫn luôn nghĩ?", "SWD9999001", 99.0, 90.0, 80.0, 85.0, 5, 1, "Không Phải Sói Nhưng Cũng Đừng Là Cừu" },
                    { 2, "Tống Mặc", 1, "Sai lầm lớn nhất của chúng ta là đem những tật xấu, những cảm xúc tiêu cực trút bỏ lên những người xung quanh, càng là người thân càng dễ gây thương tổn.\r\n\r\nCái gì cũng nói toạc ra, cái gì cũng bộc lộ hết không phải là thẳng tính, mà là thiếu bản lĩnh. Suy cho cùng, tất cả những cảm xúc tiêu cực của con người đều là sự phẫn nộ dành cho bất lực của bản thân. Nếu bạn đúng, bạn không cần phải nổi giận. Nếu bạn sai, bạn không có tư cách nổi giận.\r\n\r\nĐem một nắm muối bỏ vào cốc nước, cốc nước trở nên mặn chát. Đem một nắm muối bỏ vào hồ nước, hồ nước vẫn ngọt lành. Lòng người cũng vậy, càng nông cạn càng dễ biến chất, càng sâu sắc càng khó lung lay. Ý nghĩa của đời người không ngoài việc tu tâm dưỡng tính, để mở lòng ra bao la như biển hồ, trước những nắm muối thị phi của cuộc đời vẫn thản nhiên không xao động.", "CAW777777701", 40.0, 30.0, 20.0, 25.0, 5, 1, "Nóng Giận Là Bản Năng , Tĩnh Lặng Là Bản Lĩnh" },
                    { 3, "Joseph Murphyc", 1, "Là một trong những quyển sách về nghệ thuật sống nhận được nhiều lời ngợi khen và bán chạy nhất mọi thời đại, Sức Mạnh Tiềm Thức đã giúp hàng triệu độc giả trên thế giới đạt được những mục tiêu quan trọng trong đời chỉ bằng một cách đơn giản là thay đổi tư duy.\r\n\r\nSức Mạnh Tiềm Thức giới thiệu và giải thích các phương pháp tập trung tâm thức nhằm xoá bỏ những rào cản tiềm thức đã ngăn chúng ta đạt được những điều mình mong muốn.\r\n\r\nSức Mạnh Tiềm Thức không những có khả năng truyền cảm hứng cho người đọc, mà nó còn rất thực tế vì được minh hoạ bằng những ví dụ sinh động trong cuộc sống hằng ngày. Từ đó, Sức Mạnh Tiềm Thức giúp độc giả vận dụng năng lực trí tuệ phi thường tiềm ẩn troing mỗi người để tạo dựng sự tự tin, xây dựng các mối quan hệ hoà hợp, đạt được thành công trong sự nghiệp, vượt qua những nỗi sợ hãi và ám ảnh, xua đi những thói quen tiêu cực, và thậm chí còn hướng dẫn cách ta chữa lành những vết thương về thể chất cũng như tâm hồn để có sự bình an, hạnh phúc trọn vẹn trong cuộc sống.", "RITO5555501", 55.0, 50.0, 35.0, 40.0, 5, 1, "Sách Sức Mạnh Tiềm Thức" },
                    { 4, "Nhà Xuất Bản Thế Giới", 3, "Một thay đổi tí hon có thể biến đổi cuộc đời bạn không?\r\n\r\nHẳn là khó đồng ý với điều đó. Nhưng nếu bạn thay đổi thêm một chút? Một chút nữa? Rồi thêm một chút nữa? Đến một lúc nào đó, bạn phải công nhận rằng cuộc sống của mình đã chuyển biến nhờ vào một thay đổi nhỏ\r\n\r\nVà đó chính là sức mạnh của thói quen nguyên tử.\r\n\r\n<Nội dung sách không thay đổi / Hình bìa có thể thay đổi tùy theo từng đợt nhập hàng> ", "WS3333333301", 70.0, 65.0, 55.0, 60.0, 5, 1, "Thay Đổi Tí Hon, Hiệu Quả Bất Ngờ " },
                    { 5, "Ron Parker", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, 5, 1, "Sách Đi Tìm Lẽ Sống" },
                    { 6, "Thích Nhất Hạnh", 3, "Nhiều người trong chúng ta tin rằng cuộc đời của ta bắt đầu từ lúc chào đời và kết thúc khi ta chết. Chúng ta tin rằng chúng ta tới từ cái Không, nên khi chết chúng ta cũng không còn lại gì hết. Và chúng ta lo lắng vì sẽ trở thành hư vô.\r\n\r\nBụt có cái hiểu rất khác về cuộc đời. Ngài hiểu rằng sống và chết chỉ là những ý niệm không có thực. Coi đó là sự thực, chính là nguyên do gây cho chúng ta khổ não. Bụt dạy không có sinh, không có diệt, không tới cũng không đi, không giống nhau cũng không khác nhau, không có cái ngã thường hằng cũng không có hư vô. Chúng ta thì coi là Có hết mọi thứ. Khi chúng ta hiểu rằng mình không bị hủy diệt thì chúng ta không còn lo sợ. Đó là sự giải thoát. Chúng ta có thể an hưởng và thưởng thức đời sống một cách mới mẻ.\r\n\r\nKhông diệt Không sinh Đừng sợ hãi là tựa sách được Thiền sư Thích Nhất Hạnh viết nên dựa trên kinh nghiệm của chính mình. Ở đó, Thầy Nhất Hạnh đã đưa ra một thay thế đáng ngạc nhiên cho hai triết lý trái ngược nhau về vĩnh cửu và hư không: “Tự muôn đời tôi vẫn tự do. Tử sinh chỉ là cửa ngõ ra vào, tử sinh là trò chơi cút bắt. Tôi chưa bao giờ từng sinh cũng chưa bao giờ từng diệt” và “Nỗi khổ lớn nhất của chúng ta là ý niệm về đến-đi, lui-tới.”", "FOT000000001", 25.0, 23.0, 20.0, 22.0, 5, 1, "Không Diệt Không Sinh Đừng Sợ Hãi" },
                    { 9, " Otegha Uwagba", 4, "Bạn là một phụ nữ thuộc tuýp workaholic? Bạn là người mới bắt đầu đi làm và đã có trải nghiệm, nhưng vẫn có các thắc mắc chưa thể giải quyết? Đây chính là cuốn sách dành cho bạn.\r\n\r\n”Sách Đen” là tuyển chọn những lời khuyên cho sự nghiệp được đúc kết từ những hiểu biết và trải nghiệm đầy khôn ngoan và sâu sắc của tác giả Otegha Uwagba (người sáng lập Women-Who, một cộng đồng được tạo ra để kết nối và giúp đỡ những người phụ nữ làm việc sáng tạo) cùng rất nhiều người người phụ nữ thành công khác.\r\n\r\nTừ những điều nhỏ nhặt như viết email sao cho tinh tế hay sử dụng Instagram sao cho có lợi; đến những vấn đề nan giải mang tính quyết định, như làm thế nào để xây dựng một thương hiệu cá nhân có thể mở ra nhiều cơ hội, hay việc liệu có nên làm việc tự do hay không…", "SWD9999009", 140.0, 120.0, 110.0, 115.0, 5, 2, "Bộ Công Cụ Của Phụ Nữ Thành Đạt" },
                    { 10, "Rosie Nguyễn", 5, "“Bạn hối tiếc vì không nắm bắt lấy một cơ hội nào đó, chẳng có ai phải mất ngủ.\r\nBạn trải qua những ngày tháng nhạt nhẽo với công việc bạn căm ghét, người ta chẳng hề bận lòng.\r\n\r\nBạn có chết mòn nơi xó tường với những ước mơ dang dở, đó không phải là việc của họ.\r\n\r\nSuy cho cùng, quyết định là ở bạn. Muốn có điều gì hay không là tùy bạn.\r\n\r\nNên hãy làm những điều bạn thích. Hãy đi theo tiếng nói trái tim. Hãy sống theo cách bạn cho là mình nên sống.\r\n\r\nVì sau tất cả, chẳng ai quan tâm.”\r\n\r\n“Tôi đã đọc quyển sách này một cách thích thú. Có nhiều kiến thức và kinh nghiệm hữu ích, những điều mới mẻ ngay cả với người gần trung niên như tôi.\r\n\r\nTuổi trẻ đáng giá bao nhiêu? được tác giả chia làm 3 phần: HỌC, LÀM, ĐI..", "SWD9999010", 90.0, 80.0, 70.0, 75.0, 100, 2, "Tuổi Trẻ Đáng Giá Bao Nhiêu" },
                    { 11, "David A. Phillips", 1, "Thay Đổi Cuộc Sống Với Nhân Số Học\r\n\r\nCuốn sách Thay đổi cuộc sống với Nhân số học là tác phẩm được chị Lê Đỗ Quỳnh Hương phát triển từ tác phẩm gốc “The Complete Book of Numerology” của tiến sỹ David A. Phillips, khiến bộ môn Nhân số học khởi nguồn từ nhà toán học Pythagoras trở nên gần gũi, dễ hiểu hơn với độc giả Việt Nam.\r\n\r\nĐầu năm 2020, chuỗi chương trình “Thay đổi cuộc sống với Nhân số học” của biên tập viên, người dẫn chương trình quen thuộc tại Việt Nam Lê Đỗ Quỳnh Hương ra đời trên Youtube, với mục đích chia sẻ kiến thức, giúp mọi người tìm hiểu và phát triển, hoàn thiện bản thân, các mối quan hệ xã hội thông qua bộ môn Nhân số học. Chương trình đã nhận được sự yêu mến và phản hồi tích cực của rất nhiều khán giả và độc giả sau mỗi tập phát sóng.\r\n\r\nNhân số học là một môn nghiên cứu sự tương quan giữa những con số trong ngày sinh, cái tên với cuộc sống, vận mệnh, đường đời và tính cách của mỗi người. Bộ môn này đã được nhà toán học Pythagoras khởi xướng cách đây 2.600 năm và sau này được nhiều thế hệ học trò liên tục kế thừa, phát triển.", "SWD9999011", 75.0, 65.0, 55.0, 60.0, 100, 2, "Sách Thay Đổi Cuộc Sống Với Nhân Số Học" },
                    { 12, "Trương Học Vĩ", 2, "ỔN ĐỊNH HAY TỰ DO (Yên ổn bạn thích không cho bạn được cuộc đời như mong muốn) - cuốn sách Best-seller dành cho thế hệ GEN Z, tiếp nối Hãy khiến tương lai biết ơn vì hiện tại bạn đã cố gắng hết mình.\r\n\r\nDưới góc nhìn thực tế cùng giọng văn vô cùng thẳng thắn, sắc sảo, nữ nhà văn đã thức tỉnh hàng vạn thanh niên Trung Quốc:\r\n\r\nMơ mộng viển vông - đơn giản là không có khả năng thực hiện ước mơ\r\nNếu như không có đích đến, thì gió phương nào cũng là ngược chiều\r\nKhi tâm thái thay đổi, áp lực sẽ biến thành động lực\r\nThành công chỉ ưu ái cho những người dũng cảm.", "SWD9999012", 80.0, 70.0, 60.0, 65.0, 100, 3, "Ổn Định Hay Tự Do" },
                    { 13, "Anthony Robbins", 3, "Đánh thức con người phi thường trong bạn” là cuốn sách giúp người đọc khám phá giá trị tiềm ẩn của bản thân để tạo nên những kết quả chính mình không ngờ đến. Cuốn sách được viết bởi Athony Robbins – một nhân chứng sống, một ngưỡi đã tìm được sự phi thường trong chính con người mình.\r\n\r\nTác giả của cuốn sách, Anthony Robbins từng là một đứa trẻ sống trong cảnh cô đơn vì bố mẹ ông ly dị từ sớm, mẹ ông tái hôn 2 lần. Năm 1994, Anthony Robbins phát hiện mình có một khối u ở tuyến yên, điều đó khiến tay chân ông phát triển không bình thường. Tuy vậy, ở độ tuổi 24 Anthony Robbins đã là triệu phú, sự nghiệp của ông cũng ghi đầy dấu tích khi ông là một doanh nhân thành đạt, sáng lập, điều hành 9 công ty và là một trong những tác giả có sách bán chạy nhất toàn cầu. Ông từng cố vấn cho các chuyên viên quản trị của IBM, AT&T, American Express, McDonnell-Douglas.", "SWD9999013", 110.0, 100.0, 90.0, 95.0, 100, 3, "Sách Đánh Thức Con Người Phi Thường Trong Bạn" },
                    { 14, "Shannon Thomas", 4, "THAO TÚNG TÂM LÝ\r\nTrong cuốn “Thao túng tâm lý”, tác giả Shannon Thomas giới thiệu đến độc giả những hiểu biết liên quan đến thao túng tâm lý và lạm dụng tiềm ẩn.\r\n“Thao túng tâm lý” là một dạng của lạm dụng tâm lý. Cũng giống như lạm dụng tâm lý, thao túng tâm lý có thể xuất hiện ở bất kỳ môi trường nào, từ bất cứ đối tượng độc hại nào. Đó có thể là bố mẹ ruột, anh chị em ruột, người yêu, vợ hoặc chồng, sếp hay đồng nghiệp… của bạn. Với tính chất bí hiểm, âm thầm gây hại, thao túng, lạm dụng tâm lý làm tổn thương cảm xúc, lòng tự trọng, cuộc sống của mỗi nạn nhân. Những người từng bị lạm dụng tâm lý thường không thể miêu tả rõ ràng điều gì đã xảy ra với mình. Trong nhiều trường hợp, nạn nhân bị thao túng đến mức tự hỏi có phải họ là người có lỗi, thậm chí họ có phải là người độc hại trong mối quan hệ đó.", "SWD9999014", 95.0, 85.0, 75.0, 80.0, 100, 3, "Thao túng tâm lý" },
                    { 15, "Ngô Đức Vượng", 5, "Cơ thể được xây đắp bởi đồ ăn thức uống hàng ngày, nguồn năng lượng cho chúng ta hoạt động cũng từ đó. Vì vậy, hiểu biết Minh triết trong Ăn uống của phương Đông là điều vô cùng cần thiết. Tác giả Ngô Đức Vượng từ lâu đã quan tâm tới vấn đề này. Ông đã ăn chay trường, ăn gạo lứt muối vừng, nhịn ăn chữa bệnh cho chính mình và giúp cho nhiều người thực hành tự chữa bệnh, dưỡng sinh, nâng cao sức khỏe, thu nhiều kết quả tốt đẹp từ nhiều năm nay. Với thiện chí đem lại sức khỏe và trị bệnh không dùng thuốc, ít tốn kém, dễ thực hành…cho cộng đồng, tác giả đã viết cuốn sách này, nhằm cống hiến cho bạn đọc những lời khuyên quý giá và đáp ứng những nhu cầu cần thiết cho độc giả.", "SWD9999015", 120.0, 100.0, 90.0, 95.0, 100, 3, "Minh Triết Trong Ăn Uống Của Phương Đông" },
                    { 16, "Nhóm tác giả", 1, "Người Trong Muôn Nghề là cuốn sách hướng nghiệp tuyển tập những câu chuyện đi làm tâm huyết từ những cây viết dày dặn kinh nghiệm trong các lĩnh vực và môi trường làm việc khác nhau, giúp các bạn học sinh, sinh viên có một cái nhìn toàn diện hơn về thế giới công việc thực thụ nhằm định hướng nghề nghiệp toàn diện.", "SWD9999016", 85.0, 75.0, 65.0, 70.0, 100, 3, "Người trong muôn nghề" },
                    { 17, "Chi Nguyễn – The Present Writer", 2, "Tối giản, theo quan điểm của tác giả, không chỉ đơn thuần là bỏ đi cái quần, cái áo dư thừa hay dọn dẹp nhà cửa sạch sẽ, mà là cả một “cuộc cách mạng” từ bên trong để biến cuộc sống của mình trở nên tích cực, hiệu năng và ý nghĩa hơn. Nói cách khác, cuốn sách khai thác mọi khía cạnh của cuộc sống dưới góc nhìn tối giản toàn diện (holistic minimalism).\r\n\r\n\r\nCuốn sách này không cho bạn một “công thức chuẩn” để đánh giá thế nào là tối giản và thế nào là không tối giản, hay sống như thế nào mới là hạnh phúc, là đáng sống. Cũng sẽ không có điều gì hoàn toàn đúng và hoàn toàn sai áp đặt lên bạn. Thay vào đó, cuốn sách giới thiệu những khái niệm mở, truyền cảm hứng để bạn thay đổi tư duy và tự đưa ra quyết định đâu là lối sống phù hợp nhất với mình.", "SWD9999017", 140.0, 120.0, 110.0, 115.0, 100, 3, "Một Cuốn Sách Về Chủ Nghĩa Tối Giản" },
                    { 18, "Lý Thế Cường", 3, "Hội chứng sợ xã hội đã trở thành một “căn bệnh của thời đại”.\r\n\r\nNgày nay tuy mật độ dân số trong thành phố dày đặc nhưng con người ngày càng sợ hãi xã giao, họ sẵn sàng lựa chọn ở một mình thay vì qua lại thân thiết với người thân, bạn bè hay đồng nghiệp. Với lý do chính là sợ giao tiếp với người khác, không biết giao tiếp như thế nào, khi cần giao tiếp thì toàn thân cảm thấy căng thẳng, bồn chồn. Lâu dần họ trở nên mặc cảm, tự ti với chính mình.\r\n\r\nCó hàng ngàn nguyên nhân tồn tại khiến con người thích ở một mình, tuy nhiên đây cũng là một hiện tượng khá quan ngại. Đặc biệt, trong Tâm lý học, tình trạng này được nhắc đến với tên gọi - “Hội chứng sợ xã hội”. Hội chứng này thường kéo theo các bệnh tâm lý khác như trầm cảm, rối loạn lo âu xã hội, thậm chí có thể nặng nề tới mức gây ảnh hưởng tới việc đi làm, đi học hoặc trong các hoạt động đời sống hàng ngày.", "SWD9999018", 90.0, 80.0, 70.0, 75.0, 100, 3, "Ám Ảnh Sợ Xã Hội" },
                    { 19, "Tô Mạn", 4, "Vì sao có những cô gái cuộc sống lúc nào cũng gặp may mắn, đi làm thì dễ dàng thăng tiến, về nhà thì được chồng yêu thương, gia đình thuận hoà chẳng cãi vã bao giờ? Tất cả là nhờ “Trí thông minh của sự tinh tế\" cả đấy! “Trí thông minh\" ấy không phải sẵn có trời sinh mà là do quá trình rèn giũa tạo thành.\r\n\r\nThành thật mà nói thì phụ nữ, ai mà chẳng muốn được yêu chiều? Nhưng đôi khi muốn được cưng chiều mà không khéo léo lại thành đòi hỏi. Đôi khi đặt ra những tiêu chuẩn cho các mối quan hệ, nhưng không biết cách diễn đạt sẽ thành thực dụng…\r\n\r\nThẳng thắn không xấu nhưng sống tinh tế sẽ tốt hơn rất nhiều. Khi có được “Trí thông minh của sự tinh tế\" bạn sẽ biết:\r\n\r\nBộc lộ nhu cầu không có gì sai nhưng phải “đòi hỏi\" làm sao mà người ta sẽ vui vẻ, tự nhiên thực hiện điều đó cho mình trong hạnh phúc.\r\nHiểu rõ bản thân, nhưng cũng hiểu rõ người bên cạnh. Biết yêu chính mình nhưng càng biết yêu thương người khác.\r\nCó được hạnh phúc mà không quên đi lòng biết ơn. Được cưng chiều cũng sẽ không quên chăm sóc, quan tâm đến đời sống, tinh thần của người mình yêu thương,", "SWD9999019", 75.0, 65.0, 55.0, 60.0, 100, 3, "Trí Thông Minh Của Sự Tinh Tế" },
                    { 20, "Nguyễn Đoàn Minh Thư", 5, "“Đó là mùa hè năm 2020, mùa hè của COVID-19 và một ngàn vạn khủng hoảng tuổi đôi mươi. Đó là mùa hè mình bắt chuyến bay sớm nhất có thể vào ngày 20 tháng 3 để chạy khỏi nước Anh đang bùng dịch, bị kẹt lại sân bay Bangkok trong 24 giờ đồng hồ vì chuyến bay quá cảnh về Sài Gòn bị huỷ\r\nĐó là mỗi đêm mùa hè nằm trên giường stress chuyện deadline luận văn, stress chuyện thất nghiệp không kiếm ra tiền, stress chuyện bỏ lỡ cơ hội thực tập giúp ích cho sự nghiệp của mình, stress chuyện học hành dở dang - không biết bao giờ mới có thể quay lại Anh và hoàn thành tấm bằng đại học, stress chuyện tồn tại một cách mơ hồ, không biết mình là ai.”\r\n\r\nHành tinh của một kẻ nghĩ nhiều là hành trình khám phá thế giới nội tâm của một người trẻ. Đó là một hành tinh đầy hỗn loạn của những suy nghĩ trăn trở, những dằn vặt, những cuộc chiến nội tâm, những cảm xúc vừa phức tạp cũng vừa rất đỗi con người. Một thế giới quen thuộc với tất cả chúng ta.", "SWD9999020", 100.0, 90.0, 80.0, 85.0, 100, 3, "Hành Tinh Của Một Kẻ Nghĩ Nhiều" },
                    { 21, "Albert Rutherford", 1, "Như bạn có thể thấy, chìa khóa để trở thành một người có tư duy phản biện tốt chính là sự tự nhận thức. Bạn cần phải đánh giá trung thực những điều trước đây bạn nghĩ là đúng, cũng như quá trình suy nghĩ đã dẫn bạn tới những kết luận đó. Nếu bạn không có những lý lẽ hợp lý, hoặc nếu suy nghĩ của bạn bị ảnh hưởng bởi những kinh nghiệm và cảm xúc, thì lúc đó hãy cân nhắc sử dụng tư duy phản biện! Bạn cần phải nhận ra được rằng con người, kể từ khi sinh ra, rất giỏi việc đưa ra những lý do lý giải cho những suy nghĩ khiếm khuyết của mình. Nếu bạn đang có những kết luận sai lệch này thì có một sự thật là những đức tin của bạn thường mâu thuẫn với nhau và đó thường là kết quả của thiên kiến xác nhận, nhưng nếu bạn biết điều này, thì bạn đã tiến gần hơn tới sự thật rồi!\r\n\r\nNhững người tư duy phản biện cũng biết rằng họ cần thu thập những ý tưởng và đức tin của mọi người. Tư duy phản biện không thể tự nhiên mà có.\r\n\r\nNhững người khác có thể đưa ra những góc nhìn khác mà bạn có thể chưa bao giờ nghĩ tới, và họ có thể chỉ ra những lỗ hổng trong logic của bạn mà bạn đã hoàn toàn bỏ qua. Bạn không cần phải hoàn toàn đồng ý với ý kiến của những người khác, bởi vì điều này cũng có thể dẫn tới những vấn đề liên quan đến thiên kiến, nhưng một cuộc thảo luận phản biện là một bài tập tư duy cực kỳ hiệu quả.", "SWD9999001", 99.0, 90.0, 80.0, 85.0, 5, 1, "Rèn Luyện Tư Duy Phản Biện" },
                    { 22, "Minh Niệm", 2, "Xuất bản lần đầu tiên vào năm 2011, Hiểu Về Trái Tim trình làng cũng lúc với kỷ lục: cuốn sách có số lượng in lần đầu lớn nhất: 100.000 bản. Trung tâm sách kỷ lục Việt Nam công nhận kỳ tích ấy nhưng đến nay, con số phát hành của Hiểu về trái tim vẫn chưa có dấu hiệu chậm lại.Là tác phẩm đầu tay của nhà sư Minh Niệm, người sáng lập dòng thiền hiểu biết(Understanding Meditation),kết hợp giữa tư tưởng Phật giáo Đại thừa và Thiền nguyên thủy Vipassana, nhìn về cõi thế.Ở đó,có hạnh phúc,có đau khổ,có tình yêu,có cô đơn,có tuyệt vọng,có lười biếng,có yếu đuối,có buông xả… Nhưng, tất cả những hỉ nộ ái ố ấy đều được khoác lên tấm áo mới, một tấm áo tinh khiết và xuyên suốt,khiến người đọc khi nhìn vào, đều thấy mọi sự như nhẹ nhàng hơn…", "SWD9999003", 120.0, 100.0, 90.0, 95.0, 5, 2, "Sách Hiểu Về Trái Tim" },
                    { 23, "Osho", 3, "“YÊU” TRONG TỈNH THỨC VỚI OSHO\r\n\r\nMột chỉ dẫn “yêu không sợ hãi” đầy ngạc nhiên từ bậc thầy tâm linh Osho\r\n\r\n\r\nNhững người đói khát trong nhu cầu, những người luôn kỳ vọng ở tình yêu chính là những người đau khổ nhất. Hai kẻ đói khát tìm thấy nhau trong một mối quan hệ yêu đương cùng những kỳ vọng người kia sẽ mang đến cho mình thứ mình cần – về cơ bản sẽ nhanh chóng thất vọng về nhau và cùng mang đến ngục tù khổ đau cho nhau. Trong cuốn sách Yêu, Osho - bậc thầy tâm linh, người được tôn vinh là một trong 1000 người kiến tạo của thế kỷ 20 – đã đưa ra những kiến giải sâu sắc về nhu cầu tâm lý có sức mạnh lớn nhất của nhân loại và “chỉ cho chúng ta cách trải nghiệm tình yêu”.", "SWD9999003", 85.0, 75.0, 65.0, 70.0, 5, 2, "Yêu Trong Tỉnh Thức" },
                    { 24, "Robin Sharma", 4, "VỊ Tu Sĩ Bán Chiếc FERRARI không phải là một cuốn sách xa lạ, cuốn sách này là một trong những ấn phẩm kinh điển của thế giới về đề tài truyền cảm hứng, theo đuổi lý tưởng sống, và hướng về một cuộc sống hạnh phúc. Đây cũng là cuốn sách đầu tiên mà tác giả, nhà diễn thuyết nổi tiếng thế giới Robin Sharma chấp bút.\r\n\r\nCuốn sách gây được tiếng vang khi xuất bản năm 1997 và bán được hơn 3 triệu bản vào năm 2013.\r\n\r\n“Vị tu sĩ bán chiếc Ferrari” là một câu chuyện đầy cảm hứng cung cấp bạn đọc cách sống can đảm, cân bằng, phong phú và nhiều niềm vui hơn.\r\n\r\nSách kể về Julian Manter, một luật sư thành công nhưng trong sâu thẳm anh lại là một con người đầy đau khổ, căng thẳng. Trong một vụ kiện, Julian đột quỵ và phải nhập viện. Ngay sau khi xuất viện, Julian bỗng…biến mất.", "SWD9999004", 150.0, 130.0, 120.0, 125.0, 5, 2, "Sách Vị Tu Sĩ Bán Chiếc Ferrari " },
                    { 25, "Richard Nicholls", 5, "Một ngày, chúng ta có khoảng 16 tiếng tiếp xúc với con người, công việc, các nguồn thông tin từ mạng xã hội, loa đài báo giấy… Việc này mang đến cho bạn vô vàn cảm xúc, cả tiêu cực lẫn tích cực.\r\n\r\nBạn có thể thấy vui khi nhìn một em bé đến trường nhưng 5 phút sau đã nổi cơn tam bành khi bị đứa trẻ con đi xe đạp đâm sầm vào lại còn ăn vạ.\r\n\r\nHoặc bạn rất dễ phát điên nếu như chỉ còn 5 giây nữa đèn giao thông chuyển từ đỏ sang xanh mà kẻ đi đằng sau bấm còi inh ỏi.\r\n\r\nHay là, bạn thấy buồn chỉ vì hôm nay trời mưa man mác, mà vẫn phải ngồi trong văn phòng làm việc, bạn bi quan rằng tuổi trẻ thật buồn tẻ.\r\n\r\nHãy thừa nhận đi! Ai trong số chúng ta cũng sẽ trải qua những điều này. Và cuốn sách này dạy bạn cách làm hòa với chính những tiêu cực bên trong mình…", "SWD9999005", 95.0, 85.0, 75.0, 80.0, 5, 2, "Cân Bằng Cảm Xúc Cả Lúc Bão Giông" },
                    { 26, "Giác Minh Luật", 2, "Vẻ Đẹp Của Sự Cô Đơn\r\n\r\nMọi lời nói, việc làm đều được chi phối bởi định luật nhân quả, nó là một quy luật rất tự nhiên. Trong tình yêu cũng vậy, nếu chúng ta chỉ vì tham vọng bản thân mà nói, mà làm cho thỏa mãn những ảo mộng ở hiện tại, thì kết quả nhận lại chỉ là sự ca tụng, niềm hoan lạc và cả sự hạnh phúc tạm thời. Và rồi ngay cả khi bạn ngỡ rằng m.ình đang sống một đời bình yên với những thứ hiện có, sự cô đơn vẫn xâm chiếm và khiến trái tim bạn khổ đau.\r\n\r\n“Vẻ đẹp của sự cô đơn” là tựa sách được thầy Giác Minh Luật viết dựa trên những trải nghiệm cá nhân, nơi thầy chủ động đối diện với sự cô đơn và coi nónhư một phần trong cuộc sống của m.ìông trốn chạy, không lẩn tránh, sư thầy Giác Minh Luật chấp nhận một cách rất tự nhiên những điều đến và đi trong đời m.ình, giúp các bạn đọc trẻ có thêm bài học về cách làm chủcảm xúc, thấy rõ chính m.ình, để có thêmthời gian mang lại những giá trị cao quýkhác.", "SWD9999006", 110.0, 100.0, 90.0, 95.0, 5, 2, "Vẻ Đẹp Của Sự Cô Đơn" },
                    { 27, "Hiroko Mizushima", 1, "Trong cuộc sống thường nhật, nếu tâm trí của bạn luôn bị chi phối bởi những suy nghĩ tiêu cực như không biết người khác nghĩ gì về mình, mọi hành động và lời nói của mình sẽ khiến mọi người cảm thấy ra sao, nếu không hoàn thành tốt công việc thì hậu quả sẽ như thế nào… thì chứng tỏ bạn đang có những dấu hiệu của một người nhạy cảm, và đây chính là cuốn sách dành cho bạn.\r\nViệc chúng ta để tâm đến cảm xúc của chính mình và ý kiến của người khác là điều rất tốt, bởi nó sẽ giúp chúng ta gắn kết bản thân với thế giới xung quanh. Song nếu tính nhạy cảm quá cao, chúng ta sẽ rất dễ tức giận, buồn rầu, sợ hãi và tổn thương, gây ảnh hưởng không nhỏ tới chất lượng cuộc sống, các mối quan hệ cũng như khiến chúng ta không đủ tự tin để phát huy hết năng lực của bản thân.\r\n\r\nCuốn sách này là tổng hợp những phương pháp vô cùng hiệu quả được viết bởi một bác sỹ - chuyên gia tâm lý học hàng đầu Nhật Bản giúp bạn làm chủ vô vàn cảm xúc của chính mình, cũng như cách thức để bạn luôn có được trạng thái thân an tâm lạc thay vì rơi vào vòng xoáy bế tắc dù là trong bất cứ hoàn cảnh nào. Hy vọng qua cuốn sách này, bạn sẽ buông bỏ được mọi âu lo, sống đúng với con người mình và có một cuộc đời an yên, hạnh phúc.\r\n\r\n", "SWD9999007", 120.0, 100.0, 90.0, 95.0, 5, 2, "Sách Tâm Lý Dành Cho Người Nhạy Cảm" },
                    { 28, "Diệp Hồng Vũ", 3, "TÂM LÝ HỌC TỘI PHẠM - PHÁC HỌA CHÂN DUNG KẺ PHẠM TỘI\r\n\r\nTội phạm, nhất là những vụ án mạng, luôn là một chủ đề thu hút sự quan tâm của công chúng, khơi gợi sự hiếu kỳ của bất cứ ai. Một khi đã bắt đầu theo dõi vụ án, hẳn bạn không thể không quan tâm tới kết cục, đặc biệt là cách thức và động cơ của kẻ sát nhân, từ những vụ án phạm vi hẹp cho đến những vụ án làm rúng động cả thế giới.\r\n\r\nLấy 36 vụ án CÓ THẬT kinh điển nhất trong hồ sơ tội phạm của FBI, “Tâm lý học tội phạm - phác họa chân dung kẻ phạm tội” mang đến cái nhìn toàn cảnh của các chuyên gia về chân dung tâm lý tội phạm. Trả lời cho câu hỏi: Làm thế nào phân tích được tâm lý và hành vi tội phạm, từ đó khôi phục sự thật thông qua các manh mối, từ hiện trường vụ án, thời gian, dấu tích,… để tìm ra kẻ sát nhân thực sự.", "SWD9999008", 95.0, 85.0, 75.0, 80.0, 5, 2, "Phác Họa Chân Dung Kẻ Phạm Tội" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);
        }
    }
}
