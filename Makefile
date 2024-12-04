clean:
	rm -f inputs.txt
	rm -f last-output.txt
	rm -rf bin
	rm -rf obj

grab-input:
	python3 GetInput.py 4 > inputs.txt

paste-inputs:
	wl-paste > inputs.txt

run:
	dotnet run | tee last-output.txt

