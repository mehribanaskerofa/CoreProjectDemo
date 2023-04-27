--create trigger AddBlogInRaytingTable
--on Blogs
--After Insert
--As

--declare @id int

--select @id=BlogID from inserted

--insert into BlogRaytings(BlogID,BlogTotalScore,BlogRaytingCount)
--values (@id,0,0)  


create trigger AddScoreInComment
on comments
after insert
as
declare @id int
declare @score int
declare @raytingCount int

Select @id=BlogID, @score=BlogScore from inserted

Update BlogRaytings set BlogTotalScore=BlogTotalScore+@score, BlogRaytingCount+=1
where BlogID=@id