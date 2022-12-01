package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func getMaxValue(s []int) int {
	maxVal := 0
	for i := 0; i < len(s); i++ {
		if s[i] > maxVal {
			maxVal = s[i]
		}
	}
	return maxVal
}

func main() {
	dat, err := os.ReadFile("input.txt")
	check(err)
	scanner := bufio.NewScanner(strings.NewReader(string(dat)))
	slice := make([]int, 0)
	total := 0
	for scanner.Scan() {

		if scanner.Text() == "" {
			slice = append(slice, total)
			total = 0
		} else {
			nr, err := strconv.Atoi(scanner.Text())
			check(err)
			total = total + nr
		}
	}

	fmt.Println(getMaxValue(slice))
}
