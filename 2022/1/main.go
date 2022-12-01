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

func takeMaxValue(s []int) (int, []int) {
	maxVal := 0
	index := 0
	for i := 0; i < len(s); i++ {
		if s[i] > maxVal {
			maxVal = s[i]
			index = i
		}
	}

	return maxVal, remove(s, index)
}

func remove(s []int, i int) []int {
	s[i] = s[len(s)-1]
	return s[:len(s)-1]
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

	bigTotal := 0

	for i := 0; i < 3; i++ {
		total, slice = takeMaxValue(slice)
		fmt.Println(total)
		bigTotal += total
	}
	fmt.Println(bigTotal)
}
