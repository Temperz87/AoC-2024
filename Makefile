clean:
	rm -f inputs.txt
	rm -f last-output.txt
	rm -rf bin
	rm -rf obj

grab-input:
	python3 GetInput.py 2 > inputs.txt

run:
	dotnet run | tee last-output.txt
