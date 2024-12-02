import requests
import sys

day = sys.argv[1]
url = "https://adventofcode.com/2024/day/" + str(day) + "/input"
session = requests.Session()
funny_number = FINDOUTYOURSELF
session.cookies.set("session", funny_number)
r = session.get(url)
print(str(r.content)[2:].replace("\\n", "\n")[0: -1].strip(), end='')