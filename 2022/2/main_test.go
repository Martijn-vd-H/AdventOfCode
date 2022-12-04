package main

import (
	"testing"
)

func TestGetScore(t *testing.T) {
	input := [][]string{
		{"A", "Y"},
		{"B", "X"},
		{"C", "Z"},
	}

	inputReader := func() [][]string {
		return input
	}

	result := GetScore(inputReader)
	expected := 15
	if result != expected {
		t.Errorf("result was %q, expected %q", result, expected)
	}
}
