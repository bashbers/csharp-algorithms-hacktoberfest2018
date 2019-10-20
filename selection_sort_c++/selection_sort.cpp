#include <iostream>
#include <vector>
using namespace std;

void selection_sort(vector<int> seq);

int main () {
    vector<int> seq;
    int vector_dim;
    int temp;

    cout << "This software sort a vector of integers using selection sort algorithm." << endl;

    cout << "Insert vector dimension: ";
    cin >> vector_dim;

    if(vector_dim == 0) {
        cout << "Invalid vector dimension" << endl;
        return 0;
        }

    cout << "Insert numbers separated by space: ";

    for(unsigned i=0; i<vector_dim; i++) {
        cin >> temp;
        seq.push_back(temp);
    }

    selection_sort(seq);
}

void selection_sort(vector<int> seq) {
    for(unsigned i=0; i<seq.size(); i++) {
        int min=seq[i];
        int ind=i;

        for(unsigned j=i; j<seq.size(); j++)
            if(seq[j] < min) {
                min=seq[j];
                ind=j;
                }

        int temp=seq[i];
        seq[i]=min;
        seq[ind]=temp;
    }

    for(unsigned i=0; i<seq.size(); i++)
        cout << seq[i] << " ";
}